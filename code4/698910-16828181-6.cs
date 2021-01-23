     public static bool IsValidInt32(this string value)
     {
         int result;
         return int.TryParse(value, out result);
     }
