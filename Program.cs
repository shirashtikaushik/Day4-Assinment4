using System;
using System.Collections.Generic;

class Product
{
    private static double discountPercentage = 0.5;

    // Properties
    public int PCode;
    public string PName;
    public int QtyInStock;
    public string Brand;

    // Constructor
    public Product(int pCode, string pName, int qtyInStock, string brand)
    {
        PCode = pCode;
        PName = pName;
        QtyInStock = qtyInStock;
        Brand = brand;
    }

    // Method to take inputs from Admin
    public static Product TakeInputFromAdmin()
    {
        Console.WriteLine("Enter Product Code:");
        int pCode = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Product Name:");
        string pName = Console.ReadLine();

        Console.WriteLine("Enter Quantity in Stock:");
        int qtyInStock = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Brand:");
        string brand = Console.ReadLine();

        return new Product(pCode, pName, qtyInStock, brand);
    }

    // Method to display product details
    public void DisplayProductDetails()
    {
        Console.WriteLine($"Product Code: {PCode}");
        Console.WriteLine($"Product Name: {PName}");
        Console.WriteLine($"Quantity in Stock: {QtyInStock}");
        Console.WriteLine($"Brand: {Brand}");
    }

   // calculate total amount for a customer
    public double CalculateTotalAmount()
    {
        // apply the discount
        double discount = discountPercentage * 100;
        Console.WriteLine($"Applying {discount}% discount on all products.");

        // Calculate total amount with discount
        double totalAmount = QtyInStock * 10 * (1 - discountPercentage);
        return totalAmount;
    }

    // Method to produce bill
    public void ProduceBill(double totalAmount)
    {
        Console.WriteLine($"Product: {PName}");
        Console.WriteLine($"Quantity: {QtyInStock}");
        Console.WriteLine($"Total Amount to be Paid: {totalAmount:C}");
    }

}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();

        // Admin operations
        Console.WriteLine("Who are you? (1) Admin (2) Customer");
        int userType = Convert.ToInt32(Console.ReadLine());

        if (userType == 1)
        {
            // Admin
            while (true)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Product newProduct = Product.TakeInputFromAdmin();
                        products.Add(newProduct);
                        Console.WriteLine("Product added successfully!");
                        break;

                    case 2:
                        foreach (var product in products)
                        {
                            product.DisplayProductDetails();
                            Console.WriteLine();
                        }
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    case 4:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;


                    case 5:
                        Product newProduct = Product.TakeInputFromAdmin();
                        products.Add(newProduct);
                        Console.WriteLine("Product added successfully!");
                        break;


                }
            }
        }
        else if (userType == 2)
        {
            // Customer
            Console.WriteLine("Enter the product name you want to purchase:");
            string productName = Console.ReadLine();

            
            Product selectedProduct = products.Find(p => p.PName == productName);

            if (selectedProduct != null)
            {
                selectedProduct.DisplayProductDetails();

                double totalAmount = selectedProduct.CalculateTotalAmount();

                selectedProduct.ProduceBill(totalAmount);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
        else
        {
               Console.WriteLine("Invalid user type.");
        }
    }
}
