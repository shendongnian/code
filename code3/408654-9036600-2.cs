    public static class Objects
    {
      public static bool Equals<T>(T item1, T item2, Func<T, IEnumerable<object>> selector)
      {
        if (object.ReferenceEquals(item1, item2) return true;
        if (item1 == null || item2 == null) return false;
        using (var iterator1 = selector(item1).GetEnumerator())
        using (var iterator2 = selector(item2).GetEnumerator())
        {
          while (iterator1.MoveNext() && iterator2.MoveNext())
          {
            if (!Equals(iterator1.Current, iterator2.Current)) return false;
          }
        }
        return true;
      }
      public static bool Equals(object item1, object item2)
      {
        return object.Equals(item1, item2);
      }
 
      public static int GetHashCode(params object[] objects) 
      {
        unchecked
        {
          int hash = 17;
          foreach (var item in objects)
          {
            hash = hash * 31 + item.GetHashCode();
          }
          return hash;
        }
      }
    }
