    static class MyEnumerable {
      public static TSource LastNotEmpty<TSource>(this IEnumerable<TSource> source) {
        if (source==null) return null;  // Deals with null collection
        return source.LasdtOrDefault(x=>
                                        !ReferenceEquals(x,null)
                                        &&
                                        !x.Equals(String.Empty)
                                     );
      }
    }
