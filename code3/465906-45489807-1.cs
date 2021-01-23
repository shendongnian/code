    [TestMethod]
    [TestCategory("MemoryCacheExtensionsTests"), TestCategory("UnitTests")]
    public void MemoryCacheExtensions_LazyAddOrGetExitingItem_Test()
    {
        const int expectedValue = 42;
        const int cacheRecordLifetimeInSeconds = 42;
        var key = "lazyMemoryCacheKey";
        var absoluteExpiration = DateTimeOffset.Now.AddSeconds(cacheRecordLifetimeInSeconds);
        var lazyMemoryCache = MemoryCache.Default;
        #region Cache warm up
        var actualValue = lazyMemoryCache.LazyAddOrGetExitingItem(key, () => expectedValue, absoluteExpiration);
        Assert.AreEqual(expectedValue, actualValue);
        #endregion
        #region Get value from cache
        actualValue = lazyMemoryCache.LazyAddOrGetExitingItem(key, () => expectedValue, absoluteExpiration);
        Assert.AreEqual(expectedValue, actualValue);
        #endregion
    }
