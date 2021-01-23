    var cache = new MemoryCaching();
    
    var getVal = cache.Get<Int32>(
        "TestKey",
        () => { return 2; },
        DateTime.UtcNow.AddMinutes(5));
    
    Assert.AreEqual(2, getVal);
    
    getVal = cache.Get<Int32>(
        "TestKey",
        () => { throw new Exception("This should not be called as the value should be cached"); },
        DateTime.UtcNow.AddMinutes(5));
    
    Assert.AreEqual(2, getVal);
