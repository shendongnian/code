    public static string EscapeLikeValue(string valueWithoutWildcards)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < valueWithoutWildcards.Length; i++)
      {
         char c = valueWithoutWildcards[i];
         if (c == '*' || c == '%' || c == '[' || c == ']')
           sb.Append("[").Append(c).Append("]");
         else if (c == '\'')
           sb.Append("''");
         else
         sb.Append(c);
       }
       return sb.ToString();
    }
