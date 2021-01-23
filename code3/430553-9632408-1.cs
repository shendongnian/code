    class Program {
    
        static void Main(string[] args) {
        
            var config = new HttpSelfHostConfiguration("http://localhost:9000");
         
            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}", 
                new { id = RouteParameter.Optional }
            );
         
            using (HttpSelfHostServer server = new HttpSelfHostServer(config)) {
            
                server.OpenAsync().Wait();
                
                Console.WriteLine("Browse to http://localhost:9000/api/service");
                Console.WriteLine("Press Enter to quit.");
                
                Console.ReadLine();
            }
            
        }
    }
    
    public class ServiceController : ApiController {    
        
        public HttpResponseMessage GetHome() {
        
            return new HttpResponseMessage() {
            
                Content = new StringContent("Welcome Home", Encoding.UTF8, "text/plain")
            };    
        }
    }
