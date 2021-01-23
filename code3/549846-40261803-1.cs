      // this piece of code in the WebApiConfig.cs file or your custom bootstrap application class
      // define two types of routes 1. DefaultActionApi  and 2. DefaultApi as below
       config.Routes.MapHttpRoute("DefaultActionApi", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
       config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { action = "Default", id = RouteParameter.Optional });
      // decorate the controller action method with [ActionName("Default")] which need to invoked with below url
      // http://localhost:XXXXX/api/Demo/ -- will invoke the Get method of Demo controller
      // http://localhost:XXXXX/api/Demo/GetAll -- will invoke the GetAll method of Demo controller
      // http://localhost:XXXXX/api/Demo/GetById -- will invoke the GetById method of Demo controller
      // http://localhost:57870/api/Demo/CustomGetDetails -- will invoke the CustomGetDetails method of Demo controller
      // http://localhost:57870/api/Demo/DemoGet -- will invoke the DemoGet method of Demo controller
             
     
     public class DemoController : ApiController
     {
        // Mark the method with ActionName  attribute (defined in MapRoutes) 
        [ActionName("Default")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Get Method");
        }
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "GetAll Method");
        }
        public HttpResponseMessage GetById()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Getby Id Method");
        }
        
        //Custom Method name
        [HttpGet]
        public HttpResponseMessage DemoGet()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "DemoGet Method");
        }
        
        //Custom Method name
        [HttpGet]
        public HttpResponseMessage CustomGetDetails()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "CustomGetDetails Method");
        }
    }
