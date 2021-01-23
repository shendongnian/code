    [TestMethod]
    public void RunTest()
    {
        bool asyncDone = false;
        // this is a dummy async task - replace it with any awaitable Task<T>
        var task = Task.Factory.StartNew(() => 
        {
            // throw here to simulate bad code
            // throw new Exception();
            // Do some stuff
            asyncDone = true;
        });
        // Use Task.Wait to pause the test thread while the background code runs.
        // Any exceptions in the task will be rethrown from here.
        task.Wait();
        // check our result was as expected
        Assert.AreEqual(true, asyncDone);
    }
