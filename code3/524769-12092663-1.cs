    public class Test
    {
      public T GetInstance<T>() where T : class
      {
    	return (T)GetInstance(typeof(T));
      }
      
      private object GetInstance(Type type) 
      {
    	 return Activator.CreateInstance(type);
      }
    
      public T GetEvenMoreGenericInstance<T>()
      {
    	 if( !typeof( T ).IsValueType )
    	 {
    		return (T)GetInstance(typeof(T));
    	 }
    	 return default( T );
      }
    }
