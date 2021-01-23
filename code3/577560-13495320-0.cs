    int dynamicNumber = 6;
    
    string pattern = string.Format("({0})", dynamicNumber);
    
    string data = "My Header 6:";
    
    Console.WriteLine (Regex.Replace(data,pattern, "!!!")); // My Header !!!:
