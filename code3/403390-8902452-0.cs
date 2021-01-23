    var cacheProvider = AppServices.Cache; // will pick cachadapter using web.config ( can be Http, Memory, AppFabric or MemCached)
    
    var data1 = cacheProvider.Get<SomeData>("cache-key", DateTime.Now.AddSeconds(3), () =>
    {
        // This is the anonymous function which gets called if the data is not in the cache.
        // This method is executed and whatever is returned, is added to the cache with the
        // passed in expiry time.
        Console.WriteLine("... => Adding data to the cache... 1st call");
        var someData = new SomeData() { SomeText = "cache example1", SomeNumber = 1 };
        return someData;
    });
