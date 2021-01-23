    bool eventFired = false;
    var reset = new System.Threading.ManualResetEvent(true);
    cache.AddCacheLevelCallback(DataCacheOperations.AddItem | DataCacheOperations.RemoveItem,
        (cacheName, region, key, itemVersion, operationId, notificationDescriptor) => {
            eventFired = true;
            reset.Set();
        });
    cache.Add(key, "my value 1");
    if (!reset.WaitOne(TimeSpan.FromSeconds(10)))
    {
        throw new Exception("Didn't receive cache callback after 10 seconds");
    }
    Assert.IsTrue(eventFired);
