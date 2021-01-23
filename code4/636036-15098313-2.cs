    [TestMethod]
    public async Task Get_RetrievesExpectedString()
    {
      var tcs = new TaskCompletionSource<string>();
      var client = new ... // arrange
      client.Get(uri, acceptHeader, result =>
      {
        tcs.SetResult(result);
      });
      var actual = await tcs.Task;
      Assert.AreEqual(expected, actual);
    }
