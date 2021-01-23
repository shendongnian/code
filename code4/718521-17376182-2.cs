    if (double.TryParse("2.3", NumberStyles.Number, CultureInfo.CurrentCulture, out result))
    {
    	Console.WriteLine(result);
    }
    
    if (double.TryParse("3.4", NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result))
    {
    	Console.WriteLine(result);
    }
    
    if (double.TryParse("5,6", NumberStyles.Any, CultureInfo.GetCultureInfo("fr-CA"), out result))
    {
    	Console.WriteLine(result);
    }
    
    if (double.TryParse("7.8", NumberStyles.Any, CultureInfo.InvariantCulture, out result))
    {
    	Console.WriteLine(result);
    }
