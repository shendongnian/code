    [ExpectedException(typeof(NotImplementedException))]
    [TestMethod]
    public void TestGetInt()
    {
        TaskFactory.FromAsync(client.BeginGetInt, client.EndGetInt, null, null)
                   .ContinueWith(result =>
                       {
                           Assert.IsNotNull(result.Exception);
                       }
    }
