    String str = "test=\"-\"1\"";
    
    Regex regExpr = new Regex("\".*\"", RegexOptions.IgnoreCase);
    String result = regExpr.Replace(str , "\"31\"");
    Console.WriteLine(result);
