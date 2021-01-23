    public class Singleton
    {
       private static readonly Lazy<Singleton> instance = new Lazy<Singleton>( ()=> new Singleton());
       private Singleton() {}
       public static Singleton Instance
       {
          get 
          {
             return instance.Value;
          }
       }
    }
