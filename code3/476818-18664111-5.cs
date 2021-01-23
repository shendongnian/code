        private static void RegisterServices(IKernel kernel)
        {
             kernel.Bind(x =>
                x.FromAssembliesMatching("MyNameSpace.*")
                 .SelectAllClasses()
                 .BindAllInterfaces()
             );
             kernel.ReBind<IContestsContext>()
                  .To<ContestsContext>()
                  .InRequestScope();
