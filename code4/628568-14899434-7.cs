    public static class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>()
                  .ToMethod(context => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>()
                  .To<HttpApplicationInitializationHttpModule>();
            kernel.RegisterServices();
            return kernel;
        }
        private static void RegisterServices(this IKernel kernel)
        {
            kernel.Bind<IMemoryCacheService>()
                  .To<MemoryCacheService>()
                  .InSingletonScope();
                  // InSingletonScope() is important so Ninject knows
                  // to create only one copy and then reuse it every time
                  // it is asked for
            // ignore the stuff below... I have left it in here for illustration
            kernel.Bind<IDbTransactionFactory>()
                  .To<DbTransactionFactory>()
                  .InRequestScope();
            kernel.Bind<IDbModelContext>()
                  .To<DbModelContext>()
                  .InRequestScope();
            kernel.Bind<IDbModelChangeContext>()
                  .To<DbModelChangeContext>()
                  .InRequestScope();
            kernel.Bind<IUserContext>()
                  .To<UserContext>()
                  .InRequestScope();
            kernel.BindAttributeAndFilter<IgnoreNonAjaxRequestsFilter, IgnoreNonAjaxRequestsAttribute>();
            kernel.BindAttributeAndFilter<ProvideApplicationInfoFilter, ProvideApplicationInfoAttribute>();
            kernel.BindAttributeAndFilter<ProvideSessionInfoFilter, ProvideSessionInfoAttribute>();
            kernel.BindAttributeAndFilter<UseDialogLayoutFilter, UseDialogLayoutAttribute>();
            kernel.BindAttributeAndFilter<CheckResourceAccessFilter, CheckResourceAccessAttribute>();
            kernel.BindAttributeAndFilter<CheckResourceStateFilter, CheckResourceStateAttribute>();
        }
        private static void BindAttributeAndFilter<TFilter, TAttribute>(this IKernel kernel)
        {
            kernel.BindFilter<TFilter>(FilterScope.Action, null)
                  .WhenControllerHas<TAttribute>();
            kernel.BindFilter<TFilter>(FilterScope.Action, null)
                  .WhenActionMethodHas<TAttribute>();
        }
    }
