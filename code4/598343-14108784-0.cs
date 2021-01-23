    [Route("/hello","GET")]
    [Route("/hello/{Name}","POST,GET")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }
