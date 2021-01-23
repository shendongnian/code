    public class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
                
            Container.AddNewExtension<EnterpriseLibraryCoreExtension>();
            Container.AddNewExtension<LoggingUnityExtension>();
            // ... 
        }
        
        // ...
    }
