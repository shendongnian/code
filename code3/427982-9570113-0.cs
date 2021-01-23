    public class MvcApplication : HttpApplication
    {
        public void Application_Start()
        {
            // register areas
            RegisterAllAreas();
    
            // register other stuff...
        }
        public virtual void RegisterAllAreas()
        {
            AreaRegistration.RegisterAllAreas();
        }
    }
