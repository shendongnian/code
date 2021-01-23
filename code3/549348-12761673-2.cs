    [Route("/req/{Id}", "GET")]
    public class Req2 {}
    
    [Route("/req/{Id}", "GET")]
    public class Req1 {}
    
    public class MyService : Service {
        public object Get(Req1 request) { ... }		
        public object Get(Req2 request) { ... }		
    }
