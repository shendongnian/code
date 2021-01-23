    public class NinjectDependencyResolver : System.Web.Http.Services.IDependencyResolver
    {
        private static IKernel m_Kernel;
        public NinjectDependencyResolver()
        {
            m_Kernel = new StandardKernel();
        }
        public NinjectDependencyResolver(IKernel myKernel)
        {
            m_Kernel = myKernel;
        }
        public object GetService(Type serviceType)
        {
            return m_Kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return m_Kernel.GetAll(serviceType);
        }
    }
