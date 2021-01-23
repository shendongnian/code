    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ResponseTypeAttribute : Attribute
    {
       public ResponseTypeAttribute(Type type)
       {
           if (type == null)
           {
               throw new ArgumentNullException("type");
           }
    
           Type = type;
       }
    
       public Type Type { get; private set; }
    }
