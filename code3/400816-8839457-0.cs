    [WebMethod]
    public static string DoSomething()
    {
        NinjectModule module = new YourModule();
        IKernel kernel = new StandardKernel(module);
        var controller = kernel.Get<ISecurityController>();
        controller.WriteToLog();
    }
