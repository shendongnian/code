    /// <summary>
    /// Bind the given interface in request scope
    /// </summary>
    public static class IocExtensions
    {
        public static void BindInRequestScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }
        public static void BindInSingletonScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new ContainerControlledLifetimeManager());
        }
    }
    /// <summary>
    /// The injection for Unity
    /// </summary>
    public static class UnityHelper
    {
        public static IUnityContainer Start()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new Unity.Mvc4.UnityDependencyResolver(container));
            return container;
        }
        /// <summary>
        /// Inject
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // Database context, one per request, ensure it is disposed
            container.BindInRequestScope<IMVCForumContext, MVCForumContext>();
            container.BindInRequestScope<IUnitOfWorkManager, UnitOfWorkManager>();
            //Bind the various domain model services and repositories that e.g. our controllers require         
            container.BindInRequestScope<ITopicService, TopicService>();
            container.BindInRequestScope<ITopicTagRepository, TopicTagRepository>();
            //container.BindInRequestScope<ISessionHelper, SessionHelper>();
            return container;
        }
    }
