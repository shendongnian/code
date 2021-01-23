    using System.IO;
    using System.Security.AccessControl;
    ...
    FileSecurity security = File.GetAccessControl(@"C:\MyFolder\My File.txt");
    
    AuthorizationRuleCollection acl = security.GetAccessRules(
       true, true, typeof(System.Security.Principal.NTAccount));
    foreach (FileSystemAccessRule ace in acl)
    {
       var user = ace.IdentityReference.Value;
       var rights = ace.FileSystemRights;
       var allowOrDeny = ace.AccessControlType;
       // ...
    }
