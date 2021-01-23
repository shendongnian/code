    //C# code
    
    public static bool TryParse(
    	string s,
    	out decimal result
    )
    
    //Example
    value = "-1.643e6";
    if (Decimal.TryParse(value, out number))
       Console.WriteLine(number);
    else
       Console.WriteLine("Unable to parse '{0}'.", value);   
