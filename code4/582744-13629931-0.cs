    protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
    {
      var hostname = base.CreateServiceHost(serviceType, baseAddresses);
      hostname.Extensions.Add(new CustomConfigurer());
      return hostname;
    }
