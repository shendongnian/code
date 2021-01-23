    protected static bool IdentityClaimToFilter(string identity, string identityFormat, ref string filter, bool throwOnFail)
    {
      if (identity == null)
        identity = "";
      StringBuilder filter1 = new StringBuilder();
      switch (identityFormat)
      {
        case "ms-guid":
          Guid guid;
          try
          {
            guid = new Guid(identity);
          }
          catch (FormatException ex)
          {
            if (throwOnFail)
              throw new ArgumentException(ex.Message, (Exception) ex);
            else
              return false;
          }
    ...
