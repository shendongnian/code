    /// <summary>
    ///   Create an xml string in the expected format for the login API call.
    /// </summary>
    /// <param name="user">The user name to login with.</param>
    /// <param name="password">The password to login with.</param>
    /// <returns>
    ///   Returns the string of an xml document with the expected schema, 
    ///   to use with the login API.
    /// </returns>
    private static string GenerateXmlForLogin(string user, string password)
    {
        return string.Format(
            "<Envelope><Body><Login><USERNAME>{0}</USERNAME><PASSWORD>{1}</PASSWORD></Login></Body></Envelope>",
            user,
            password);
    }
