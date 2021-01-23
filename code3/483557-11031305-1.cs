    static bool LessThan2DecimalPlaces(string mystring, out decimal val)
    {
        bool validDecimal = decimal.TryParse(mystring, out val);
        if (!validDecimal)
        {
           return false;
        }
        
       var index = mystring.LastIndexOf('.');
       if(index == -1)
       {
           return true;
       }
       return mystring.Substring(index).Count() < 3
    }
  
