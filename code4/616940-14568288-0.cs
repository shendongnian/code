    using System.DirectoryServices;
    ...
    
    DirectoryEntry de = new DirectoryEntry();
    de.Username = "username@mysite.com";
    de.Password = "password";
    de.Path = "LDAP://DC=mysite,DC=com";
    de.AuthenticationType = AuthenticationTypes.Secure;
    DirectorySearcher des = new DirectorySearcher(de);
