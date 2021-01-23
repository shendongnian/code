    public class MyOptionalServicesPlugin : IPlugin
    {
        public void Register(IAppHost appHost)
        {
             var settings = new AppSettings();
             var enableSpecialService1 = settings.Get<bool>("enableSpecialService1", false);
             if (enableSpecialService1)
             {
                 appHost.RegisterService(typeof(SpecialService1), new[] { "/special/service-1" });
             }
             ...
        }
     }
