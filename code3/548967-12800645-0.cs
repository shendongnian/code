    ServiceHost host = new ServiceHost(typeof(Service));
    try
    {
        host.Open();
        Console.WriteLine("WCF Service is ready for requests." +  
        "Press any key to close the service.");
        Console.WriteLine();
        Console.Read();
        Console.WriteLine("Closing service...");
    }
    finally
    {
        if (host!=null) {
                host.Close();
                host=null;
        }
    }
