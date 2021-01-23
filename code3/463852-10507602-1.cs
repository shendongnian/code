    var httpResult = TestService(serviceHttp.Search, criteria);
    var tcpResult = TestService(serviceTcp.Search, criteria);
    var localResult = TestService(servicelocal.Search, criteria);
    
    ...
    
    private static double TestService<T>(Action<T> serviceOperation, T parameter)
    {
        const int iterations = 15;
        ...
    
        for (var i = 0; i < iterations; i++)
        {
            var watch = Stopwatch.StartNew();
    
            ...
    
            string typeName = serviceOperation.Method.DeclaringType.Name
            string methodName = serviceOperation.Method.Name;
            Console.WriteLine(string.Format("{0}.{1} ElapsedMilliseconds={2}", typeName, methodName, watch.ElapsedMilliseconds));
             // Ideally this would print something like "serviceTcp.DoStuff(...) ElapsedMilliseconds=313"
        }
    
        ...
    }
