    public static class MyExtensions {
      /// <summary>Gets an enumerable of all ancestors.</summary>
      public static IEnumerable<T> Ancestors<T>(this T obj, Func<T, T> expr) where T : class {
        obj = expr.Invoke(obj);
        while(obj != null) {
          yield return obj;
          obj = expr.Invoke(obj);
      }
    }
