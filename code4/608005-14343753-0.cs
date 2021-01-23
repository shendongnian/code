    public class ClassName {
      public static Object CachedObject {
        get {
          Object o = (Object)Cache['CacheKey'];
          if (o == null)
          {
             o = GetData();
             Cache["CacheKey"] = o;
          }
          return o;
        }
      }
    }
