    public class YourController : Controller
     {
         private IConfigService _configService;
         
         //inject your configuration object here.
         public YourController(IConfigService configService){
               // A guard clause to ensure we have a config object or there is something wrong
               if (configService == null){
                   throw new ArgumentNullException("configService");
               }
               _configService = configService;
         }
     }
