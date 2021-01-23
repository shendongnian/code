    Console.Write("Input price: ");
    double price;
    string inputPrice = Console.ReadLine();
    var num = Decimal.Parse(inputPrice); //Use tryParse here for safety
    if (decimal.Round(num , 2) == num)
    {
       //You pass condition
    }
    else
    {
        Console.WriteLine("Inventory code is invalid!");
    }
     
