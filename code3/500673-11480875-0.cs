    public class OAuthHostFactory : NinjectWebServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var host = base.CreateServiceHost(serviceType, baseAddresses);
            host.Authorization.ServiceAuthorizationManager = new OAuthAuthorizationManager();
            return host;
        }
    }
