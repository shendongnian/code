    // Test fixture level
    ManualResetEvent mre = new ManualResetEvent(false);                                
    [TestMethod]     
    public void TestMethod()     
    {                     
        // start waiting task with cancellation token
        Task task = Task.Factory.StartNew(() =>
            {
                // Test Body HERE!
                // ... 
    
                // if test passed - set event explicitly
                mre.Set();
            });
    
        // Timeout handling logic, 
        // !!! I believe you can put it once in the TestInitialize, just check
        // whether Assert.Fail() fails the test when called from TestInitialize
        mre.WaitOne(5000);
    
        // Check whether ManualResetEvent was set explicitly or was timeouted
        if (!mre.WaitOne(0))
        {
            task.Dispose();
            Assert.Fail("Timeout");
        }                
    }                    
