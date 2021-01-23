    public static String WhiteSpaceReducer(String value) {
      if (String.IsNullOrEmpty(value))
        return value;
      Boolean wasWhiteSpace = false;
      StringBuilder Sb = new StringBuilder();
      foreach (Char Ch in value) 
        if (Char.IsWhiteSpace(Ch)) {
          if (!wasWhiteSpace)
            Sb.Append(Ch);
          wasWhiteSpace = true;
        }
        else {
          wasWhiteSpace = false;
          Sb.Append(Ch);
        }
      return Sb.ToString();
    }
    ...
    String test = "   test   me  out  ";
    String result = WhiteSpaceReducer(test);
