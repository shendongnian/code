    // Setup the WCF pipeline.
    public static IMyInterface pipeProxy { get; protected set;}
    ServiceHost host = UserCostServiceLibrary.Wcf
        .OpenServiceHost<UserCostTsqlPipe, IMyInterface>(
            myClassInheritingFromIMyInterface, "net.pipe://localhost/YourAppName");
    pipeProxy = UserCostServiceLibrary.Wcf.AddListnerToServiceHost<IMyInterface>("net.pipe://localhost/YourOtherAppName");
