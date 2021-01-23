    public databaseactivity(ServiceclientFactory serviceClientFactory = null, /*...*/)
    {
      // ...
      this.serviceClientFactory = serviceClientFactory ?? new DefaultServiceClientFactory();
    }
    public int insert(bo obj)   
    {   
      serviceClient = this.serviceClientFactory.CreateServiceClient(); 
      serviceClient.insert(obj);
    }
