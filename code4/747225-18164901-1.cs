    private bool DirectoryCanListFiles(string folder)
    {
        bool hasAccess = false;
        //Step 1. Get the userName for which, this app domain code has been executing
        string executingUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        NTAccount acc = new NTAccount(executingUser);
        SecurityIdentifier secId = acc.Translate(typeof(SecurityIdentifier)) as SecurityIdentifier;
    
        DirectorySecurity dirSec = Directory.GetAccessControl(folder);
    
        //Step 2. Get directory permission details for each user/group
        AuthorizationRuleCollection authRules = dirSec.GetAccessRules(true, true, typeof(SecurityIdentifier));                        
    
        foreach (FileSystemAccessRule ar in authRules)
        {
            if (secId.CompareTo(ar.IdentityReference as SecurityIdentifier) == 0)
            {
                var fileSystemRights = ar.FileSystemRights;
                Console.WriteLine(fileSystemRights);
    
                //Step 3. Check file system rights here, read / write as required
                if (fileSystemRights == FileSystemRights.Read ||
                    fileSystemRights == FileSystemRights.ReadAndExecute ||
                    fileSystemRights == FileSystemRights.ReadData ||
                    fileSystemRights == FileSystemRights.ListDirectory)
                {
                    hasAccess = true;
                }
            }
        }
        return hasAccess;
    }
