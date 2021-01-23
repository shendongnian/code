    ServiceHost myserviceHost = new ServiceHost(typeof(MyService), new Uri(Environment.bindAddress));
    
    foreach (ServiceEndpoint endpoint in myserviceHost.Description.Endpoints)
    {
       endpoint.Behaviors.Add(new LogMessageBehavior());
    }
    myserviceHost.Open();
    Console.WriteLine(myserviceHost.BaseAddresses[0]);
    Console.ReadLine();
