    string someString = "1,2,3"; 
 
    bool myResults = someString.Split(';').
           Any<string>(s => !isNumeric(s)); 
    if(myResults)
      Console.Writeln("invalid number");
    else
      Console.Writeln("valid number");
    
    
    public bool isNumeric(string val)
    {
        if(val == String.Empty)
          return false;       
        int result;
        return int.TryParse(val,out result);
    }
