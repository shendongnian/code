    // Here here here here here here :)
    using conf = System.Configuration.ConfigurationManager;
    
    public class MyClass 
    {
       public void MethodOne()
       {
          string appConfigStr = conf.AppSettings["someAppSettings"].ToString()
       }
    }
