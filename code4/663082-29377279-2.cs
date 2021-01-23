    public static class MyExtensions {
      /// <summary>Returns an ancestor count.</summary>
      public static int AncestorCount<T>(this T obj, Func<T, T> expr) where T : class {
       	int count = -1;
       	
       	while(obj != null) {
       	  count++;
       	  obj = expr.Invoke(obj);
       	}
       	return count;
      }
      /// <summary>Gets an enumerable of all ancestors.</summary>
      public static IEnumerable<T> Ancestors<T>(this T obj, Func<T, T> expr) where T : class {
        obj = expr.Invoke(obj);
        while(obj != null) {
          yield return obj;
          obj = expr.Invoke(obj);
      }
    }
