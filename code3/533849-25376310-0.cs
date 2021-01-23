        [Route("/Hello")]
        [RequestAspect]
        public class HelloRequest
        {
            public string hello { get; set; }
        }
        [ResponseAspect]
        public class HelloResponse
        {
            public string hello { get; set; }
        }
        public class HelloService : Service
        {
            public object Any(HelloRequest req)
            {
                return new HelloResponse
                {
                    hello = req.hello
                };
            }
        }
