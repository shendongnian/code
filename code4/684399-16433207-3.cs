    class Client : IMyCallbackService
    {
        static void Main(string[] args)
        {
            new Client().Run();
        }
        public void Run()
        {
            var factory = new DuplexChannelFactory<ISimpleService>(new InstanceContext(this), new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/SimpleService"));
            var proxy = factory.CreateChannel();
            Console.WriteLine(proxy.ProcessData());
        }
        private void NotifyClient()
        {
            Console.WriteLine("Notification from Server");
        }
    }
