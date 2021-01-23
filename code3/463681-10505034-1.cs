    private const int LoopIterations = 1000;
    
    private const string ServiceClass = "Win32_Service";
    private const string ServiceName = "MyService";
    private const string ServiceProperty = "PathName";
    
    private static readonly string ServicePath = string.Format("{0}.Name=\"{1}\"", ServiceClass, ServiceName);
    private static readonly string ServiceQuery = string.Format(
	    "SELECT {0} FROM {1} Where Name=\"{2}\"",
		ServiceProperty, ServiceClass, ServiceName
	);
    private static ManagementObjectSearcher ServiceSearcher = new ManagementObjectSearcher(ServiceQuery);
    
    static void Main(string[] args)
    {
        var watch = new Stopwatch();
    
        watch.Start();
        for (int i = 0; i < LoopIterations; i++)
        {
            var servicePath = GetServicePathByKey();
        }
        watch.Stop();
        Console.WriteLine(
            "{0:N0} iterations of GetServicePathByKey() took {1:N0} milliseconds",
            LoopIterations, watch.ElapsedMilliseconds
        );
    
        watch.Restart();
        for (int i = 0; i < LoopIterations; i++)
        {
            var servicePath = GetServicePathFromExistingSearcher();
        }
        watch.Stop();
        Console.WriteLine(
            "{0:N0} iterations of GetServicePathFromExistingSearcher() took {1:N0} milliseconds",
            LoopIterations, watch.ElapsedMilliseconds
        );
    
        watch.Restart();
        for (int i = 0; i < LoopIterations; i++)
        {
            var servicePath = GetServicePathFromNewSearcher();
        }
        watch.Stop();
        Console.WriteLine(
            "{0:N0} iterations of GetServicePathFromNewSearcher() took {1:N0} milliseconds",
            LoopIterations, watch.ElapsedMilliseconds
        );
    }
    
    static string GetServicePathByKey()
    {
        using (var service = new ManagementObject(ServicePath))
            return (string) service.GetPropertyValue(ServiceProperty);
    }
    
    static string GetServicePathFromExistingSearcher()
    {
        using (var results = ServiceSearcher.Get())
        using (var enumerator = results.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                throw new Exception();
    
            return (string) enumerator.Current.GetPropertyValue(ServiceProperty);
        }
    }
    
    static string GetServicePathFromNewSearcher()
    {
        using (var searcher = new ManagementObjectSearcher(ServiceQuery))
        using (var results = searcher.Get())
        using (var enumerator = results.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                throw new Exception();
    
            return (string) enumerator.Current.GetPropertyValue(ServiceProperty);
        }
    }
