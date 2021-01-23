    [Test]
    void Should_remove_...()
    {
        MockTimer timer = new MockTimer();    
        
        MyCache cache = new MyCache(timer);
        DateTime expiredAt = DateTime.Now.Add(..);
        cache.Add("key", "value", expiredAt);
        
        timer.SetTime(expiredAt);
    
        Assert.That(cache, Is.Empty)
    }
