    container.Register(
        AllTypes
            .FromAssemblyContaining<EmailService>()
            .Where(t => t.Name.EndsWith("Service"))
            .WithService.Select(IoC.SelectByInterfaceConvention)
            .LifestylePerWebRequest()
    );
    container.Register(
        AllTypes
            .FromAssemblyContaining<EmailService>()
            .Where(t => t.Name.EndsWith("Service"))
            .WithService.Select(IoC.SelectByInterfaceConvention)
            .LifestylePerThread()
    );
