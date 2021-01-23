    ClientService clientService = new ClientService();
    clientService.Endpoint.Behaviors.Add(new YourBehaviorThatApplysYourExtension());
    InstanceContext context = new InstanceContext(clientService);
    DuplexChannelFactory<MyApp.ServiceContracts.IMyAppClientService> factory = new 
       DuplexChannelFactory<MyApp.ServiceContracts.IMyAppClientService>(context);
    factory.Credentials.UserName.UserName = anvandarNamn;
    factory.Credentials.UserName.Password = password;
    return factory.CreateChannel();
