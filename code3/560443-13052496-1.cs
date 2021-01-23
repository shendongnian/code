    public static void DoSomething(object o)
    {
     var iCollection = o as ICollection;
     if(iCollection != null)
     {
    	dynamic oc = iCollection;
    	Type t = GetGenericType(oc); 
    	// now you got your type :)
     }
    }
    
    public static Type GetGenericType<T>( List<T> o)
    {
    	return typeof(T);
    }
