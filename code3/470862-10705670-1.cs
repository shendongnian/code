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
        return
            new XElement("Envelope",
                new XElement("Body",
                    new XElement("Login",
                        new XElement("USERNAME", user),
                        new XElement("PASSWORD", password)))).ToString();
    }
