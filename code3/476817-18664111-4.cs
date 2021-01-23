        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IContestsContext>()
                  .To<ContestsContext>()
                  .InRequestScope();
            kernel.Bind(x =>
                x.FromAssembliesMatching("MyNameSpace.*")
                 .SelectAllClasses()
                 .BindAllInterfaces()
             );
