    public static class MyExtensions
    {
      public static IEnumerable<T> RunMeOnEachItemLater(this IEnumerable<T> sequence,
                                                        Action<T> action)
      {
          foreach(T item in sequence)
          {
             action(item);
             yield return item;
          }
      }
    }
