    System.Net.CredentialCache credentialCache = new System.Net.CredentialCache(); 
    credentialCache.Add(
        new System.Uri("http://www.yoururl.com/"),
        "Basic", 
        new System.Net.NetworkCredential("username", "password")
    );
