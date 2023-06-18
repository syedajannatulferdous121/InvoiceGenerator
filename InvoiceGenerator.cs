using System;
using System.Collections.Generic;

class InvoiceGenerator
{
    static void Main()
    {
        Console.WriteLine("Invoice Generator");

        // Get customer details
        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();
        Console.Write("Enter customer email: ");
        string customerEmail = Console.ReadLine();

        // Create a list to store invoice items
        List<InvoiceItem> invoiceItems = new List<InvoiceItem>();

        // Get invoice items from the user
        Console.WriteLine("Enter invoice items (enter 'done' to finish):");
        string itemName;
        double itemPrice;
        while (true)
        {
            Console.Write("Item name: ");
            itemName = Console.ReadLine();
            if (itemName.ToLower() == "done")
                break;
            Console.Write("Item price: ");
            double.TryParse(Console.ReadLine(), out itemPrice);

            // Add the item to the invoice
            invoiceItems.Add(new InvoiceItem(itemName, itemPrice));
        }

        // Get discount percentage from the user
        Console.Write("Enter discount percentage (0-100): ");
        double discountPercentage;
        double.TryParse(Console.ReadLine(), out discountPercentage);
        double discountAmount = 0;

        // Get tax percentage from the user
        Console.Write("Enter tax percentage (0-100): ");
        double taxPercentage;
        double.TryParse(Console.ReadLine(), out taxPercentage);
        double taxAmount = 0;

        // Calculate the total amount
        double totalAmount = 0;
        foreach (InvoiceItem item in invoiceItems)
        {
            totalAmount += item.Price;
        }

        // Calculate discount amount and apply it to the total amount
        if (discountPercentage > 0 && discountPercentage <= 100)
        {
            discountAmount = (discountPercentage / 100) * totalAmount;
            totalAmount -= discountAmount;
        }

        // Calculate tax amount and add it to the total amount
        if (taxPercentage > 0 && taxPercentage <= 100)
        {
            taxAmount = (taxPercentage / 100) * totalAmount;
            totalAmount += taxAmount;
        }

        // Display the invoice
        Console.WriteLine("\nInvoice:");
        Console.WriteLine("Customer Name: " + customerName);
        Console.WriteLine("Customer Email: " + customerEmail);
        Console.WriteLine("Invoice Items:");
        foreach (InvoiceItem item in invoiceItems)
        {
            Console.WriteLine(item.Name + " - $" + item.Price);
        }
        Console.WriteLine("Subtotal: $" + totalAmount);
        Console.WriteLine("Discount: $" + discountAmount);
        Console.WriteLine("Tax: $" + taxAmount);
        Console.WriteLine("Total Amount: $" + totalAmount);
    }
}

class InvoiceItem
{
    public string Name { get; set; }
    public double Price { get; set; }

    public InvoiceItem(string name, double price)
    {
        Name = name;
        Price = price;
    }
}
