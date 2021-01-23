    double price;
    if (Double.TryParse(txtPrice.Text, out price))
    {
        Console.WriteLine(price);
    }
    else
    {
        Console.WriteLine("Not a double!");
    }
