    static void Main(string[] args)
    {
        Console.WriteLine("About to call DNS");
        ResolveDnsAndPerformWorkWhileWaiting("74.125.237.112");
        Console.Read();
    }
    public static void ResolveDnsAndPerformWorkWhileWaiting(string ipaddress)
    {
        var task = new Task<string>(() =>
            {
                var host = new IPHostEntry { AddressList = new[] { IPAddress.Parse(ipaddress) } };
                var result = Dns.GetHostEntry(host.AddressList[0]);
                return result.HostName;
            });
        // execute the work on another thread
        task.Start();
        // do other stuff
            
        // use the results (if the task has not finished the .Result property will hold until completed)
        var resolvedAddress = task.Result;
        Console.WriteLine("Resolved address:" + resolvedAddress);
    }
