    [Test]
    public void TestConfigurationInStaticConstructor()
    {
        // setup configuraton to test
        // ...
        // init static constructor
        ReaderTypeInit();
        // Assert configuration effect
        // ...
        // reset static ctor to prevent other existing tests (that may depend on original static ctor) fail
        ReaderTypeInit();
    }
    // helper method
    private void ReaderTypeInit()
    {
        typeof(< your class with static ctor>).TypeInitializer.Invoke(null, new object[0]);
    }
