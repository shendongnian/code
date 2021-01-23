    IFixture fixture = new Fixture().Customize(new AutoMoqCustomization());
    
    Mock<ICache> internalCache = new Mock<ICache>();
    internalCache.Setup(i => i.Get<String>("CacheKey")).Returns("Foo");
    
    var cacheExtension = typeof(CacheExtensions);
    var inst = cacheExtension.GetField("_internalCache", BindingFlags.NonPublic | BindingFlags.Static);
    inst.SetValue(cacheExtension, internalCache.Object);
