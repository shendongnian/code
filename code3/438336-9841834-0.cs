    var result = new StringBuilder();
    
    foreach(Char c in myString)
    {
       if (Char.IsWhiteSpace(c))
       {
           // you can do what you wish here. strings are immutable, so you can only make a copy with the results you want... hence the "result" var.
    
          result.Append('_'); // for example, replace space with _
       }
       else result.Append(c);
    
    }
    
    myString = result.ToString();
