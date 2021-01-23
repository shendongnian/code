    private MyServiceClient GetMyServiceClient(string url)
    {
      Uri uri = new Uri(url);
      BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
      EndpointAddress address = new EndpointAddress(uri);
      MyServiceClient client = new MyServiceClient(binding, address);
      return client;
    }
