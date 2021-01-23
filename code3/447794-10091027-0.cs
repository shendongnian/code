    using System.DirectoryServices;
    using System.DirectoryServices.ActiveDirectory;
    private void CreateUser(string userName, string password)
    {
    DirectorySearcher dseSearcher = new DirectorySearcher();
    string rootDSE = dseSearcher.SearchRoot.Path;
    string userDSE = rootDSE.Insert(7, "OU=Users,");
    DirectoryEntry userDE = new DirectoryEntry(userDSE);
    DirectoryEntry user = userDE.Children.Add("CN=" + userID, "user");
    staff.Properties["samAccountName"].Value = userID;
    staff.Properties["UserPrincipalName"].Value = userName +
    @"@domain";
    staff.CommitChanges();
    staff.Properties["userAccountControl"].Value =
    ActiveDs.ADS_USER_FLAG.ADS_UF_NORMAL_ACCOUNT |
    ActiveDs.ADS_USER_FLAG.ADS_UF_DONT_EXPIRE_PASSWD;
    staff.CommitChanges();
    staff.Invoke("SetPassword", new Object[] { password });
    }
