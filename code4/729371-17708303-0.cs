    [MyControllerConfig]
    public class ValuesController : ApiController
----------
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MyControllerConfigAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            //remove the existing Json formatter as this is the global formatter and changing any setting on it
            //would effect other controllers too.
            controllerSettings.Formatters.Remove(controllerSettings.Formatters.JsonFormatter);
                        
            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.All;
            controllerSettings.Formatters.Insert(0, formatter);
        }
    }
