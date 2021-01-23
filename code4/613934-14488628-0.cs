    List<string> Tokenize(strInput)
    {
      var sb = new StringBuilder();
      var tokens = new List<string>();
      bool inParen = false;
      foreach(var c in strInput)
      {
          if (inParens)
          {
               if (c == ')')
                   inParens = false;
               else
                   sb.Append(c);
           }
           else if (c == '(')
                   inParens = true;
           else if (c == '/')
                {
                     tokens.Add(sb.ToString());
                     sb.Length = 0;
                }
           else
                 sb.Append(c);
            
      }
      if (sb.Length > 0)
          tokens.Add(sb.ToString());
      return tokens;
    }
