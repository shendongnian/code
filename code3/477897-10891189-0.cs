    try
    {
        var sc = new ServiceController(serviceInstaller1.ServiceName);
        sc.Start();
        System.IO.File.WriteAllText(@"c:\temp\servicestart.txt", "Service started");
    }
    catch (Exception ex)
    {
        System.IO.File.WriteAllText(@"c:\temp\servicestart.txt", ex.Message);
    }
