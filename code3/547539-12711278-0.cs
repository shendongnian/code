    public static class IntExtensions {
       public static int? AsInt(this string source) {
         int result;
         return (int.TryParse(source,out result)) ? (int?)null : result;
       }
       public static bool IsInt(this string source) {
         return source.AsInt.HasValue;
       }
    }
