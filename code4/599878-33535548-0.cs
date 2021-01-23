    [assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyApp.Api.Controllers.MyController), "AutoMapperStart")]
    
    
    namespace MyApp.Api.Controllers
    {
    
        public class MyController : ApiController
        {
            public static void AutoMapperStart()
            {
                MyMapperConfig.DefineMappings();
            }
        }
    }
