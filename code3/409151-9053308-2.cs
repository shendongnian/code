    const string VAULT_RESOURCE = "[My App] Credentials";
    string UserName { get; set; };
    string Password { get; set; };
    var vault = new PasswordVault();
    try
    {
       var creds = vault.FindAllByResource(VAULT_RESOURCE).FirstOrDefault();
       if (creds != null)
       {
          UserName = creds.UserName;
          Password = vault.Retrieve(VAULT_RESOURCE, UserName).Password;
       }
    }
    catch(COMException) 
    {
       // this exception likely means that no credentials have been stored
    }
