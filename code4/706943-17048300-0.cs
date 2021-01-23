    public static string RemoveSpecialCharacters(this string str)
    {
       StringBuilder stringBuilder  = new StringBuilder();
       foreach (char c in str)
        {
          if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') ||
              (c >= 'a' && c <= 'z') || c == '.' || c == '_') 
          {
             stringBuilder.Append(c);
          }
       }
       return stringBuilder.ToString();
    }
