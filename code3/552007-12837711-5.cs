    public static class AssertEx
    {
      public async Task ThrowsExceptionAsync<TException>(Func<Task> code)
      {
        try
        {
          await code();
        }
        catch (Exception ex)
        {
          if (ex.GetType() == typeof(TException))
            return;
          throw new AssertFailedException("Incorrect type; expected ... got ...", ex);
        }
        throw new AssertFailedException("Did not see expected exception ...");
      }
    }
