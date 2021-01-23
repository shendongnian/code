    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(HelloWorldService), new Uri("http://localhost:3264"));
            ServiceMetadataBehavior mdb = new ServiceMetadataBehavior();
            mdb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(mdb);
            host.Open();
    
            Console.WriteLine("Service Hosting...");
            Console.ReadLine();
        }
    }
    [ServiceContract]
    class HelloWorldService
    {
        [OperationContract]
        public void SendEmails()
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Start Sending Emails...");
                Thread.Sleep(10000);
                Console.WriteLine("Finish Sending Emails...");
            });
        }
    }
}
