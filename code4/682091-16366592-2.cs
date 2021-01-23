    if (sResult != null)
    {
        string userName = sResult.Properties["name"][0].ToString();
        string managerDN = sResult.Properties["manager"][0].ToString();
            
        DirectoryEntry man =  new DirectoryEntry("LDAP://server_name/"+managerDN);
        string managerName = man.Properties["name"][0].ToString();
    
    }
