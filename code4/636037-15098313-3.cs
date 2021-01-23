    [TestMethod]
    public void Get_RetrievesExpectedString()
    {
      var mre = new ManualResetEvent(initialState: false);
      string actual = null;
      var client = new ... // arrange
      client.Get(uri, acceptHeader, result =>
      {
        actual = result;
        mre.Set();
      });
      mre.WaitOne();
      Assert.AreEqual(expected, actual);
    }
