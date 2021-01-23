    namespace Playground.Sandbox
    {
        public static class Program
        {
            public static void Main()
            {
                using (var client = new MyWcfClient())
                {
                    var myEndpointBehavior = new MyEndpointBehavior();
                    
                    client.Endpoint.Behaviors.Add(myEndpointBehavior);
                    
                    // TODO: your things with the client.
                }
            }
        }
    }
