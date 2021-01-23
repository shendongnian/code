    static class TheClass
    {
       public static T Get<T>(string key)
       {
          // Adjust these as required:
          const BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic;
          
          if (typeof(T).IsGenericType && typeof(IEnumerable<>) == typeof(T).GetGenericTypeDefinition())
          {
             Type v = typeof(T).GetGenericArguments()[0];
             var baseMethod = typeof(TheClass).GetMethod("GetEnum", flags);
             var realMethod = baseMethod.MakeGenericMethod(v);
             return (T)(object)realMethod.Invoke(null, new[] { key });
          }
          
          // TODO: Handle other types...
       }
       
       private static IEnumerable<T> GetEnum<T>(string key)
       {
          // TODO: Return an enumerable...
       }
    }
