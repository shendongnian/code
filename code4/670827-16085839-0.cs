    public sealed class DefInstance
    {
      private static readonly DefInstance instance = new DefInstance();
      static DefInstance()
      {
      }
 
      private DefInstance()
      {
      }
 
      public static DefInstance Instance
      {
        get
        {
          return instance;
        }
       }
    } 
