    static void Main(string[] args)
    {
        var binding = new BasicHttpBinding();
        var endpoint = new EndpointAddress("http://localhost:8080/");
        using (var factory = new ChannelFactory<IPerson>(binding, endpoint))
        {
            var request = new Dictionary<Guid, Person>();
            request[Guid.NewGuid()] = new Person { Name = "Bob", Email = "Bob@abc.com" };
    
            var client = factory.CreateChannel();
            var result = client.SetCustomer(request);
    
            Console.WriteLine("Name: {0} | Email: {1}", result.Name, result.Email);
            factory.Close();
        }
        Console.ReadKey(true);
    }
