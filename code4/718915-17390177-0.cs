    public string AddSlash(string input)
    {
         StringBuilder sb = new StringBuilder();
         for(int i = 0;i < input.Length; i++)
         {
             if (Char.IsUpper(input[i]) && i > 0)
                sb.Append('/');
      
             sb.Append(input[i]);
         }
     
         return sb.ToString();
    }
