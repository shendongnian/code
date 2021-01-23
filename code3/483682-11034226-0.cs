    internal static void HandleFail(string assertionName, string message, params object[] parameters)
    {
      string str = string.Empty;
      if (!string.IsNullOrEmpty(message))
        str = parameters != null ? string.Format((IFormatProvider) CultureInfo.CurrentCulture, Assert.ReplaceNulls((object) message), parameters) : Assert.ReplaceNulls((object) message);
      if (Assert.AssertionFailure != null)
        Assert.AssertionFailure((object) null, EventArgs.Empty);
      throw new AssertFailedException(FrameworkMessages.AssertionFailed((object) assertionName, (object) str));
    }
