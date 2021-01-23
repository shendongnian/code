    public static string Convert(int x)
    {
         StringBuilder sb = new StringBuilder();
         while (x != 0)
         {
             sb.Insert(0, x % 10 + '0');
             x = x / 10;
         }
         return sb.ToString();
    }
