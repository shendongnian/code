    string someString = "1,2,3"; 
 
    IEnumerable<string> myResults = someString.Split(';').
           Where<string>(s => string.IsNullOrEmpty(s) || !isNumeric(s)); 
    if(myResults.Length > 0)
      Console.Writeln("invalid number");
    else
      Console.Writeln("valid number");
    
    
    public bool isNumeric(string val)
    {
        int result;
        return int.TryParse(val,out result);
    }
