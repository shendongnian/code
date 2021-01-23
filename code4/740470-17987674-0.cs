    public static T[] CreateArray<T>(int size) {
      if (size < 0)
        throw new ArgumentOutOfRangeException("size");
    
      T[] result = new T[size];
    
      // You may put any special cases here, e.g. if you want empty strings instead of nulls
      // uncomment the exerp:
      //if (typeof(T) == typeof(String)) {
      //  for (int i = 0; i < result.Length; ++i)
      //    result[i] = (T) ((Object) "");
      //   
      //  return result;  
      //}
     
      // If default value is null, instances should be created 
      // (if we manage to find out how to do it)
      if (Object.ReferenceEquals(null, default(T))) {
        // Do we have a constructor by default (public one and without parameters)?
        ConstructorInfo ci = typeof(T).GetConstructor(new Type[] { });
    
        // If do, let's create instances
        if (!Object.ReferenceEquals(null, ci))
          for (int i = 0; i < result.Length; ++i)
            result[i] = (T) (ci.Invoke(new Object[] { }));
      }
    
      return result;
    }
