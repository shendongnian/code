    public class Permission
    {
       private Permission()
       { }
    
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
