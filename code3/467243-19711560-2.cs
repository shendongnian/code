    public static class MockExtensions
    {
      public static void ExpectsInOrder<T>(this Mock<T> mock, params Expression<Action<T>>[] expressions) where T : class
      {
        // All closures have the same instance of sharedCallCount
        var sharedCallCount = 0;
        for (var i = 0; i < expressions.Length; i++)
        {
          // Each closure has it's own instance of expectedCallCount
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
