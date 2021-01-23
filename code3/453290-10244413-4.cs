    var cacheProvider = new MemoryCaching();
    
    var eventRepo = new Mock<IEventRepository>(MockBehavior.Strict);
    eventRepo
        .Setup(x => x.GetAll())
        .Returns(() =>
        {
            return new Event[] { 
                new Event() { Id = 1}, 
                new Event() { Id = 2}
            };
        });
    
    var cachedEventRepo = new CachedEventRepository(
        eventRepo.Object,
        cacheProvider);
    
    
    cachedEventRepo.CacheProvider.Clear();
    var data = cachedEventRepo.GetAll();
    data = cachedEventRepo.GetAll();
    data = cachedEventRepo.GetAll();
    Assert.IsTrue(data.Count() > 0);
    eventRepo.Verify(x => x.GetAll(), Times.Once());
    
    
    cachedEventRepo.SomeSetMethodWhichExpiresTheCache();
    data = cachedEventRepo.GetAll();
    data = cachedEventRepo.GetAll();
    Assert.IsTrue(data.Count() > 0);
    eventRepo.Verify(x => x.GetAll(), Times.Exactly(2));
