    public static class MyExtensions
    {
         public static string NullSafeTrim(this string value)
         {
             if (value != null)
             {
                 value = value.Trim();
             }
    
             return value;
         }
    }
