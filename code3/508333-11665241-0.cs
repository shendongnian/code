    using System.DirectoryServices;
    try
    {
       DirectoryEntry Ldap = new DirectoryEntry("LDAP://your-AD", "Login", "Password");
    }
    catch(Exception Ex)
    {
       Console.WriteLine(Ex.Message);
    }
