    public class UnityDependencyResolver : IDependencyResolver
    {
        public readonly IUnityContainer Container;
 
        public UnityDependencyResolver(IUnityContainer container)
        {
            Container = container;
        }
 
        #region IDependencyResolver Members
 
        public object GetService(Type serviceType)
        {
            try
            {
                return Container.Resolve(serviceType);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is TypeInitializationException)
                    throw ex.InnerException;
 
                return null;
            }
        }
        ...
