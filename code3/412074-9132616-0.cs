    public static class LogicExtensions {
      public static T OrNew<T>(this T obj) where T : class, new() {
        if (obj != null) {
          return obj;
        }
        return new T();
      }
    }
