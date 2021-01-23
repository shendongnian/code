    public static object ChangeType(object value, Type conversion) 
    {
       var t = conversion;
       
       if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>))) 
       {
           if (value == null) 
           { 
               return null; 
           }
    
           t = Nullable.GetUnderlyingType(t); ;
       }
    
       return Convert.ChangeType(value, t);
    }
