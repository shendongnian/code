    public static class Extensions
    {
       public static bool IsOneOf<T>(this T input, params T[] possibilites)
       {
          bool result = possibilites.Contains(input);
          return result;
       }
    }
