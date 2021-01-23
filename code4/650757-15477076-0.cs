    public static class Extensions
    {
      public static void Replace<T>(this IList<T> list, int index, T item)
      {
        list[index] = item;
      }
    }
