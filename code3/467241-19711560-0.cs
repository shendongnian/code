    public static class MockExtensions
    {
      public static void ExpectsInOrder<T>(this Mock<T> mock, params Expression<Action<T>>[] expressions) where T : class
      {
        // Shared counter that is incremented each time any expression is invoked
        var sharedCallCount = 0;
        for (var i = 0; i < expressions.Length; i++)
        {
          // Copy of i that is stored in each closure and compared to sharedCallCount
          var expectedCallCount = i;
          mock.Setup(expressions[i]).Callback(
            () =>
              {
                Assert.AreEqual(expectedCallCount, sharedCallCount);
                sharedCallCount++;
              });
        }
      }
    }
