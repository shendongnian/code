    public static class Objects
    {
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
