        private static IKernel CreateKernel()
        {
            var settings = new NinjectSettings { InjectNonPublic = true };
            var kernel = new StandardKernel(settings);
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            RegisterServices(kernel);
            return kernel;
        }
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<AdminHelper>().ToSelf().InRequestScope();
            kernel.Bind<AuditHelper>().ToSelf().InRequestScope();
            kernel.Bind<ErrorHelper>().ToSelf().InRequestScope();
            kernel.Bind<GoalHelper>().ToSelf().InRequestScope();
        }
