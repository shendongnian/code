    public sealed class Singleton
    {
     
       private Singleton() {}
     
       public static Singleton GetInstance()
       {
          return NestedSingleton.singleton;
       }
        
       class NestedSingleton
       {
          internal static readonly Singleton singleton = new Singleton();
     
          static NestedSingleton() {}
       }
    }
