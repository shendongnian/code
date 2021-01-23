    Uri baseAddress = new Uri("http://localhost:8080/Test");
    var serviceHost = new ServiceHost(typeof(TestService));
    var basicHttpBinding = new BasicHttpBinding();
    basicHttpBinding.MaxReceivedMessageSize = int.MaxValue;
    serviceHost.AddServiceEndpoint(typeof(IService), basicHttpBinding, baseAddress);
