    class Server
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(SimpleService), new Uri("net.pipe://localhost")))
            {
                host.AddServiceEndpoint(typeof(ISimpleService), new NetNamedPipeBinding(), "SimpleService");
                host.Open();
                Console.WriteLine("Simple Service Running...");
                Console.ReadLine();
                host.Close();
            }
        }
    }
