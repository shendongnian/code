    internal static class ServiceClass
    {
    
        internal static Object GetWCFSvc(string siteUrl)
        {
    
            Uri serviceUri = new Uri(siteUrl);
            EndpointAddress endpointAddress = new EndpointAddress(serviceUri);
    
            //Create the binding here
            Binding binding = BindingFactory.CreateInstance();
    
            ServiceClient client = new ServiceClient(binding, endpointAddress);            
            return client;
        }
    
    
    }
    
    internal static class BindingFactory
    {
        internal static Binding CreateInstance()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            binding.UseDefaultWebProxy = true;
            return binding;
        }
    
    }
