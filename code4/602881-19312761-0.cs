    [TestMethod()]
    public void Async_Test()
    {
        TypeToTest target = new TypeToTest();
        AutoResetEvent AsyncCallComplete = new AutoResetEvent(false);
        SuccessResponse SuccessResult = null;
        Exception FailureResult = null;
    
        target.AsyncMethodToTest(
            (SuccessResponse response) =>
            {
                SuccessResult = response;
                AsyncCallComplete.Set();
            },
            (Exception ex) =>
            {
                FailureResult = ex;
                AsyncCallComplete.Set();
            }
        );
    
        // Wait until either async results signal completion.
        AsyncCallComplete.WaitOne();
        Assert.AreEqual(null, FailureResult);
    }
