    //Note all clients have the name Manager, but this isn't a problem as they get resolved        
    //by type
    ChannelFactory<I> factory = new ChannelFactory<I>("Manager");
    factory.Credentials.UserName.UserName = userName;
    factory.Credentials.UserName.Password = password;
    I manager = factory.CreateChannel();
    //Wrap below in a retry loop
    return serviceCall.Invoke(manager);
}
