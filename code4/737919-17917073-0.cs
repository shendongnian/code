      String s = @"$KUH% I*$)OFNlkfn$"; 
    
      foreach (Char c in s) 
        if (!(Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c))) {
          Console.WriteLine("String contains special chars");
       
          break;
        }
