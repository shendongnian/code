    public class GreetService : Service
    {
        //1. Using Object
        public object Any(Greet request)
        {
            return new GreetResponse { Result = "Hello " + request.Name };
        }
        //2. Above service with a strong response type
        public GreetResponse Any(Greet request)
        {
            return new GreetResponse { Result = "Hello " + request.Name };
        }
    }
