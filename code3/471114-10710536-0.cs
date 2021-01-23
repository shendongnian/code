    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.State == TestState.Failure ||
            TestContext.CurrentContext.Result.State == TestState.Error)
        {
            Browser.BringToFront();
            Browser.CaptureWebPageToFile(DateTime.Now.ToString("ddmmyyyyHHmmss") + GetType().Name + ".png");
        }
        Browser.Close();
    }
