    WebHttpBinding _binding = new WebHttpBinding();
    _binding.Security.Mode = WebHttpSecurityMode.Transport;
    _binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
    m_serviceHost = new WebServiceHost(typeof(Serviceclass), new Uri("https://127.0.0.1:8085/"));
                 m_serviceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, "611fe7748c5883f8082351744604a8c917608290");
                ServiceEndpoint ep = m_serviceHost.AddServiceEndpoint(typeof(InstanceClass), _binding, "hello");
                m_serviceHost.Open();
