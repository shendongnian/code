    public static T GetDefault<T>()
    {
       if (typeof(IEnumerable).IsAssignableFrom(typeof(T)))
       {
                if (typeof(T).IsGenericType)
                {
                    Type T_template = typeof(T).GetGenericTypeDefinition();
                    if (T_template == typeof(IEnumerable<>))
                    {
                        return (T)Activator.CreateInstance(typeof(Enumerable).MakeGenericType(typeof(T).GetGenericArguments()));
                    }
                    if (T_template == typeof(IList<>))
                    {
                        return (T)Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(T).GetGenericArguments()));
                    }
                }
          try {
              return Activator.CreateInstance<T>();
          }
          catch (MissingMethodException) {} // no default exists for this type, fall-through to returning null
       }
       return default(T);   
    }
