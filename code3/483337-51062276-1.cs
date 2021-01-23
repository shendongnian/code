    // Add new user to OU
    var username = "testuser_01";
    var userDn = "LDAP://yourdomain.local:389/OU=testou,cn=yourdomain,cn=local";
    var ouUserEntry = new DirectoryEntry(userDn, "yourAdminUser", "yourAdminPassword", AuthenticationTypes.Secure);
    var newUserEntry = ouUserEntry.Children.Add("CN="+ username, "user");
    newUserEntry.Properties["sAMAccountName"].Value = username;
    newUserEntry.Properties["userPrincipalName"].Value = username + "@abc.com";
    newUserEntry.Properties["displayName"].Value = username;
    
    // Commit before enable account
    newUserEntry.CommitChanges();
    
    // Set password
    newUserEntry.Invoke("SetPassword", "yourUserPassword");
    
    // Enable Account & Password never expired (NORMAL_ACCOUNT | DONT_EXPIRE_PASSWORD)
    newUserEntry.Properties["userAccountControl"].Value = 66080; // integer value in image above
    newUserEntry.CommitChanges();
