    public interface IAccountFactory
    {
        Account Create(ISecurityContext securityContext);
    }
    public class ServiceLocatorAccountFactory : IAccountFactory
    {
        readonly IServiceLocator _serviceLocator;
        public ServiceLocatorAccountFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
        public Account Create(ISecurityContext securityContext)
        {
            var resolverType = typeof (IAccountResolver<>).MakeGenericType(securityContext.GetType());            
            dynamic resolver = _serviceLocator.GetInstance(resolverType);
            return resolver.Resolve(securityContext);
        }
    }
