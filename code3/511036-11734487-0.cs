      public static class Extensions
      {
        public static IList<T> EnsureNotNull<T>(this IList<T> list)
        {
          return list != null ? list ? new List<T>();
        }
      }
