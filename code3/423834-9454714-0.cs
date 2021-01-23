    delegate string DisplayDelegate(int value, params Func<int, string>[] formatters);
    delegate string FormatDelegate(string formatString, params object[] @params);
    static void Main()
    {
        FormatDelegate formatDelegate = (format, args) => string.Format(format, args);
        
        Console.WriteLine(formatDelegate("String with params: {0} {1}", 1, "something")); 
        //Output: "String with params: 1 something"
        
        Console.WriteLine(formatDelegate("String without params"));  
        //Output: "String without params"
    
        DisplayDelegate displayValue  = 
            (value, formatter) =>
                formatter.Length == 0 
                    ? value.ToString() 
                    : value < 0 
                        ? "N/A" 
                        : formatter[0](value);
        
        Console.WriteLine(displayValue(33));                         // "33"
        Console.WriteLine(displayValue(33, v => v.ToString("D4")));  // "0033"
        Console.WriteLine(displayValue(-33));                        // "-33"  
        Console.WriteLine(displayValue(-33, v => v.ToString("D4"))); // "N/A"
    }
 
