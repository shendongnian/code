    private string resourceName = "My App";
    private string defaultUserName;
    private void Login()
    {
        var loginCredential = GetCredentialFromLocker();
        if (loginCredential != null)
        {
            // There is a credential stored in the locker.
            // Populate the Password property of the credential
            // for automatic login.
            loginCredential.RetrievePassword();
        }
        else
        {
            // There is no credential stored in the locker.
            // Display UI to get user credentials.
            loginCredential = GetLoginCredentialUI();
        }
        // Log the user in.
        ServerLogin(loginCredential.UserName, loginCredential.Password);
    }
    private Windows.Security.Credentials.PasswordCredential GetCredentialFromLocker()
    {
        Windows.Security.Credentials.PasswordCredential credential = null;
        var vault = new Windows.Security.Credentials.PasswordVault();
        var credentialList = vault.FindAllByResource(resourceName);
        if (credentialList.Count > 0)
        {
            if (credentialList.Count == 1)
            {
                credential = credentialList[0];
            }
            else
            {
                // When there are multiple usernames,
                // retrieve the default username. If one doesn’t
                // exist, then display UI to have the user select
                // a default username.
                defaultUserName = GetDefaultUserNameUI();
                credential = vault.Retrieve(resourceName, defaultUserName);
            }
        }
        return credential;
    }
