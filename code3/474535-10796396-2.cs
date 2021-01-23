    static void Main(string[] args)
    {
        InitWindsor();
        var host = new DefaultServiceHostFactory().CreateServiceHost("MyService", new Uri[0]);
        host.Open();
        Console.ReadLine();
    }
    static IWindsorContainer Container { get; set; }
    private static void InitWindsor ()
    {
        Container = new WindsorContainer().AddFacility<WcfFacility>().Install(Configuration.FromXmlFile("windsor.config"));
    }
