    public class ServerCertificateServiceBehavior : IServiceBehavior
    {
        private X509Certificate2 certificate;
        public ServerCertificateServiceBehavior(StoreName storeName, StoreLocation storeLocation, string subjectName, string applicationPolicy)
        {
            X509Store store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            certificate = store
                .Certificates
                .Find(X509FindType.FindByApplicationPolicy, applicationPolicy, false)
                .Find(X509FindType.FindBySubjectName, subjectName, false)
                .Cast<X509Certificate2>()
                .SingleOrDefault();
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            serviceHostBase.Credentials.ServiceCertificate.Certificate = this.certificate;
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    }
