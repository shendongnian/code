    public class HelloService : Service
    {        
        public object Any(Hello request)        
        {
            string api_key = this.Request.Headers["api_key"];            
            return new HelloResponse { Result = "Hello, " + request.Name };
        }
    } 
