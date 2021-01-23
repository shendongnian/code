    public sealed class MyModelDbContextSingleton
    {
      private static readonly MyModelDbContext instance = new MyModelDbContext();
    
      static MyModelDbContextSingleton() { }
    
      private MyModelDbContextSingleton() { }
    
      public static MyModelDbContext Instance
      {
        get
        {
          return instance;
        }
      }
    }  
