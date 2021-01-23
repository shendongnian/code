    if (sResult != null)
    {
        string userName = sResult.Properties["name"][0].ToString();
        string managerCN = sResult.Properties["manager"][0].ToString();
            
        DirectoryEntry man =  new DirectoryEntry("LDAP://server_name/"+managerCN);
        string managerName = man.Properties["name"][0].ToString();
    
    }
