    public static T GetDefault<T>()
    {
       if (typeof(IEnumerable).IsAssignableFrom(typeof(T)))
       {
          try {
              return Activator.CreateInstance<T>();
          }
          catch (MissingMethodException) {} // no default exists for this type, fall-through to returning null
       }
       return default(T);   
    }
