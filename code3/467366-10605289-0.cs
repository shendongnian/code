    string Name = "MyService";
    ServiceController service = ServiceController
                            .GetServices()
                            .Where(s => s.ServiceName == Name).FirstOrDefault();
    if(null != service)
    {
        // service exists
    }
