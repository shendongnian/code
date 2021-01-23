    public static Exception Rethrow(this Exception ex)
    {
      typeof(Exception).GetMethod("PrepForRemoting",
          BindingFlags.NonPublic | BindingFlags.Instance)
          .Invoke(ex, new object[0]);
      throw ex;
    }
