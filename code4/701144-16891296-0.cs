    NumberFormatInfo nfo = new NumberFormatInfo();
    nfo.CurrencyGroupSeparator = ",";
    // you are interested in this part of controlling the group sizes
    nfo.CurrencyGroupSizes = new int[] { 3, 2 };
    nfo.CurrencySymbol = "";
    
    Console.WriteLine(15000000.ToString("c0", nfo)); // prints 1,50,00,000
