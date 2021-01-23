    public static async Task ThrowsAsync<TException>(Func<Task> func)
    {
      var expected = typeof(TException);
      Type actual = null;
      try
      {
        await func();
      }
      catch (ArgumentNullException e)
      {
        actual = e.GetType();
      }
      Assert.Equal(expected, actual);
    }
