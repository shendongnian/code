    PrincipalContext ctx = new PrincipalContext(ContextType.Domain,
                                         "test.int",
                                         "CN=Users,DC=test,DC=int",
                                         ContextOptions.Negotiate,
                                         "administrator",
                                         "SecurePassword");
    UserPrincipal usr = new UserPrincipal(ctx);
    usr.Name = "Jim Daly";
    usr.SamAccountName = "Jim.Daly";
    usr.UserPrincipalName = "Jim.Daly@test.int";
    usr.Description = "This is the user account for Jim Daly";
    usr.EmailAddress = "jimdaly@test.int";
    usr.SetPassword("VerySecurePwd");
    usr.Save();
      
    // Get the underlying directory entry.
    DirectoryEntry de = (DirectoryEntry)usr.GetUnderlyingObject();
    // Print the authentication type 
    Console.Out.WriteLine(de.AuthenticationType);
