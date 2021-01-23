    using conf = System.Configuration.ConfigurationManager;
    
    namespace MyNamespace
    {
        public class MyClass 
        {
            public void MethodOne()
            {
                string appConfigStr = conf.AppSettings["someAppSettings"].ToString()
            }
        }
    }
    
