    UInt32 result = 0;
    
    UInt32.TryParse("...",
                    new CultureInfo(""),
                    out result);
    
    if(result == 0)
    {
      Console.WriteLine("No parsing");
    }
    else
    {
     Console.WriteLine("result={0}", result);
    }
