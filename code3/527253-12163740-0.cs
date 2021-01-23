    void Main()
    {
    	Parse<Foo>();
    }
    
    public static T Parse<T>() where T : new()
    {
       var returnObj = new T();
       PropertyInfo[] properties = typeof(T).GetProperties();
       foreach (PropertyInfo p in properties)
       {
    	 // Get a meaningful property name
    	 string ins = p.PropertyType.Name;
    	 switch(ins)
    	 {
    		// populate int
    		case "Int32":
    		   p.SetValue(returnObj, 1 , null);
    		   break;
    
    		// populate list
    		case "IList`1":
    		   var list = new List<string>();
    		   // This will throw the exception 'Parameter count mismatch.'
    		   p.SetValue(returnObj, list, null);
    		   break;
    	  }
       }
       return returnObj;
    }
    
    public class Foo
    {
     public virtual int someInt {get; set;}
     public virtual IList<string> list {get; set;}
    }
