    public class MyOptionalServicesPlugin : IPlugin
    {
        public void Register(IAppHost appHost)
        {
             var settings = new AppSettings();
             var enableSpecialService1 = settings.Get<bool>("enableSpecialService1", false);
             if (enableSpecialService1)
             {
                 appHost.Routes.Add<SpecialService1Request>("/special/service-1");
             }
             ...
        }
     }
