    var myBinding = new BasicHttpBinding();
    
    var urlList = GetUrlsFromCustomConfigFile();
    
    var factoriesOfTheSameType = new List<ChannelFactory<IMyService>>();
    
    foreach(var url in urlList)
    {
        var myEndpoint = new EndpointAddress(url);
        var myChannelFactory = new ChannelFactory<IMyService>(myBinding, myEndpoint);
        factoriesOfTheSameType.Add(myChannelFactory);
    }
