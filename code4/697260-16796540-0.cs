    public ClassWithBusinessLogic()
    {
        string hostAddress = "http://localhost:1337/";
        //Simplistic business logic
        SomeBusinessLogic = "Hello";
        WebServiceHost host = new WebServiceHost("MyHost", new List<Assembly>() { typeof(DTO).Assembly });
        host.StartWebService(hostAddress);
        Console.WriteLine("Host started listening....");
        Console.ReadKey();
    }
