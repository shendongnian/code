    static class MyEnumerable {
      public static string LastNotEmpty<TSource>(this IEnumerable<TSource> source) {
        if (source==null) return null;  // Deals with null collection
        return source.OfType<string>().LastOrDefault(x=>!string.IsNullOrEmpty(x);
      }
    }
