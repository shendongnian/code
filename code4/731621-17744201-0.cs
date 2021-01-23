    string cost = "535.8";
    string decplace = "3";
    
    decimal price = decimal.Round(Convert.ToDecimal(cost), Convert.ToInt32(decplace));
    Console.WriteLine(string.Format("{0:N" + decplace + "}", price);
    Console.ReadLine();
