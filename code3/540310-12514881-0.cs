    BasicHttpSecurityMode securitymode = HostSource.Scheme.Equals("https", StringComparison.InvariantCultureIgnoreCase) ? BasicHttpSecurityMode.Transport : BasicHttpSecurityMode.None;
    BasicHttpBinding binding = new BasicHttpBinding(securitymode);
    binding.MaxReceivedMessageSize = int.MaxValue;
    binding.MaxBufferSize = int.MaxValue;
    Uri uri = new Uri(Application.Current.Host.Source, "../service.svc");
    _client = new RssArticleServiceClient(binding, new EndpointAddress(uri))
