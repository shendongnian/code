    public static T GetDefault<T>() where T : new
    {
       if (typeof(IEnumerable).IsAssignableFrom(typeof(T)))
       {
          return new T();
       }
       return default(T);   
    }
    GetDefault<List<object>>();
    
