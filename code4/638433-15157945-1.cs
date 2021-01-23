    public class Permission
    {
       private Permission()
       { }      
    
       private static Permission _instance = null;
       public static Permission Instance
       {
          get
          {
             if(_instance == null)
             {
                _instance = new Permission();
             }
             return _instance
          }
    }
