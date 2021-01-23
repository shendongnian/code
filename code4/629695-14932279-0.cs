    decimal d1;
    string s1 = "123,456.22";
    if (Decimal.TryParse(s1, 
        System.Globalization.NumberStyles.Any, 
        System.Globalization.CultureInfo.GetCultureInfo("ro-RO"), 
        out d1))
    {
        Console.WriteLine("Success: {0} converted into {1} using the ro-RO number format", 
            s1, d1);
    }
    else if (Decimal.TryParse(s1, out d1))
    {
        Console.WriteLine("Success: {0} converted into {1} using the {2} number format", 
            s1, d1,System.Globalization.CultureInfo.CurrentCulture.Name);
    }
        }
    }
