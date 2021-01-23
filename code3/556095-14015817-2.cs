    [DataContract]
    [Api("A sample web service.")]
    public class Greet
    {
        [DataMember]
        [ApiMember("The name of the person you wish to greet")]
        public string Name { get; set; }
    }
    [DataContract]
    public class GreetResponse
    {
        [DataMember]
        public string Result { get; set; }
    }
    public class GreetService : Service
    {
        public GreetResponse Any(Greet request)
        {
            return new GreetResponse { Result = "Hello " + request.Name };
        }
    }
