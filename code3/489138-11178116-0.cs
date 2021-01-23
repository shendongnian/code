    StringBuilder sb = new StringBuilder();
    
    foreach(char c in value)
    {
          if(char.IsDigit(c) || c == '.')
          {
              sb.append(c);
          }
    }
    
    return sb.ToString();
