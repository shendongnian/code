    using conf = System.Configuration.ConfigurationManager;
    public class MyClass 
    {
        public void MethodOne()
        {
            string appConfigStr = conf.AppSettings["someAppSettings"].ToString()
        }
    }
