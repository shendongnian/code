    List<IPAddress> dnsServers = new List<IPAddress>();
    NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
    foreach (NetworkInterface adapter in adapters)
    {
        IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
        IPAddressCollection adapterDnsServers = adapterProperties.DnsAddresses;
        if (adapterDnsServers.Count > 0)
            dnsServers.AddRange(adapterDnsServers);
    }
    foreach (IPAddress dnsServer in (from d in dnsServers 
                                    where d.AddressFamily == AddressFamily.InterNetwork
                                   select d))
    {
        Console.WriteLine("Using server {0}", dnsServer);
        // create a request
        Request request = new Request();
        // add the question
        request.AddQuestion(new Question("stackoverflow.com", DnsType.MX, DnsClass.IN));
        // send the query and collect the response
        Response response = Resolver.Lookup(request, dnsServer);
        // iterate through all the answers and display the output
        foreach (Answer answer in response.Answers)
        {
            MXRecord record = (MXRecord)answer.Record;
            Console.WriteLine("{0} ({1}), preference {2}", record.DomainName, Dns.GetHostAddresses(record.DomainName)[0], record.Preference);
        }
        Console.WriteLine();
    }
    Console.ReadLine();
