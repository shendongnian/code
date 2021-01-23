    public static T GetDefault<T>()
    {
       if (typeof(IEnumerable).IsAssignableFrom(typeof(T)))
       {
          if (typeof(T).IsGeneric) {
              Type T_template = typeof(T).GetGenericType();
              if (T_template == typeof(IEnumerable<>)) {
                  return Activator.CreateInstance(typeof(System.Linq.Enumerable.Empty).MakeGenericType(typeof(T).GetTypeParameters()));
              }
              else if (T_template == typeof(IList<>)) {
                  return Activator.CreateInstance(typeof(List).MakeGenericType(typeof(T).GetTypeParameters()));
              }
          }
          try {
              return Activator.CreateInstance<T>();
          }
          catch (MissingMethodException) {} // no default exists for this type, fall-through to returning null
       }
       return default(T);   
    }
