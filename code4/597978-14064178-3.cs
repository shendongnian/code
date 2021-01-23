    static void Main(string[] args)
    {
        using (ServiceHost host = new ServiceHost(typeof(PersonService), new Uri("http://localhost:8080")))
        {
            host.Open();
    
            Console.WriteLine("Ready!");
            Console.ReadKey(true);
    
            host.Close();
        }
    }
