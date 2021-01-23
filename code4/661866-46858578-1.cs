    /// <summary>
    /// Retrieve a non-permanent token to be used for any subsequent WS call.
    /// </summary>
    /// <param name="userName">a valid userName</param>
    /// <param name="password">the corresponding password</param>
    /// <returns>a GUID if authentication succeeds, or string.Empty if something goes wrong</returns>
    public string GetToken(string userName, string password)
    {
        // TODO: replace the following sample with an actual auth logic
        if (userName == "testUser" && password == "testPassword")
        {
            // Authentication Successful
            return Guid.NewGuid().ToString();
        }
        else
        {
            // Authentication Failed
            return string.Empty;
        }
    }
