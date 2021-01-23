        class Program
        {
        static void Main(string[] args)
        {
            var endPoint = new UdpDiscoveryEndpoint( DiscoveryVersion.WSDiscoveryApril2005 );
                       
            var discoveryClient = new DiscoveryClient(endPoint);
            discoveryClient.FindProgressChanged += discoveryClient_FindProgressChanged;
            FindCriteria findCriteria = new FindCriteria();
            findCriteria.Duration = TimeSpan.MaxValue;
            findCriteria.MaxResults = int.MaxValue;
            discoveryClient.FindAsync(findCriteria);
            Console.ReadKey();
        }
        static void discoveryClient_FindProgressChanged(object sender, FindProgressChangedEventArgs e)
        {
            //Check endpoint metadata here for required types.
        }
    }
