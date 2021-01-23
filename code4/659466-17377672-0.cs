    /// <summary>
    /// <para>Unity Bootstrapper for Caliburn.Micro</para>
    /// <para>You can subclass this just as you would Caliburn's Bootstrapper</para>
    /// <para>http://caliburnmicro.codeplex.com/wikipage?title=Customizing%20The%20Bootstrapper</para>
    /// </summary>
    /// <typeparam name="TRootModel">Root ViewModel</typeparam>
    public class UnityBootstrapper<TRootModel>
        : Bootstrapper<TRootModel>
        where TRootModel : class, new()
    {
        protected UnityContainer Container
        {
            get { return _container; }
            set { _container = value; }
        }
        private UnityContainer _container = new UnityContainer();
        protected override void Configure()
        {
            if (!Container.IsRegistered<IWindowManager>())
            {
                Container.RegisterInstance<IWindowManager>(new WindowManager());
            }
            if (!Container.IsRegistered<IEventAggregator>())
            {
                Container.RegisterInstance<IEventAggregator>(new EventAggregator());
            }
            base.Configure();
        }
        protected override void BuildUp(object instance)
        {
            instance = Container.BuildUp(instance);
            base.BuildUp(instance);
        }
        protected override IEnumerable<object> GetAllInstances(Type type)
        {
            return Container.ResolveAll(type);
        }
        protected override object GetInstance(Type type, string name)
        {
            var result = default(object);
            if (name != null)
            {
                result = Container.Resolve(type, name);
            }
            else
            {
                result = Container.Resolve(type);
            }
            return result;
        }
    }
