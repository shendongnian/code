    config.DependencyResolver = new MyDependencyResolver();
    public class MyDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            // return a different instance if you want to dispose resources
            return this;
        }
        public object GetService(Type serviceType)
        {
            if (t == typeof(TasksController))
            {
                return new TasksController(new TaskRepository());
            }
            if (t == typeof(OtherController))
            {
                return new OtherController();
            }
            if (t == typeof(OneMoreController))
            {
                return new OneMoreController();
            }
            return null;
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return null;
        }
        public void Dispose()
        {
        }
    }
