    [Route("/Hello/{Name}")]
    public class Hello
    {
        public string Name { get; set; }
    }
    public class HelloService : Service
    {
        public string Any(Hello request)
        {
            return request.Name;
        }
    }
