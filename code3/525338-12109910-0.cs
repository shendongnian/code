    public class ServerCertificateServiceBehavior : IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            serviceHostBase.Credentials.ServiceCertificate.Certificate =
                store
                .Certificates
                .Find(X509FindType.FindByApplicationPolicy, "1.3.6.1.5.5.7.3.1", false)
                .Find(X509FindType.FindBySubjectName, "host.domain.com", false)
                .Cast<X509Certificate2>()
                .SingleOrDefault();
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    }
