    static void Main(string[] args)
    {
        var kernel = new StandardKernel(new FooModule());
        var barDependency = kernel.Get<Bar>();
        System.ServiceProcess.ServiceBase[] ServicesToRun;
        ServicesToRun = new ServiceBase[] { new FooService(barDependency) };
        System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    }
