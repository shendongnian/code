    class Client : IMyCallbackService
    {
        static void Main(string[] args)
        {
            new Client().Run();
        }
        public void Run()
        {
            // Consume the service
            var factory = new DuplexChannelFactory<ISimpleService>(new InstanceContext(this), new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/SimpleService"));
            var proxy = factory.CreateChannel();
            Console.WriteLine(proxy.ProcessData());
        }
        public void NotifyClient()
        {
            Console.WriteLine("Notification from Server");
        }
    }
