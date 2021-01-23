            string domain;
            using (DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE"))
            {
                domain = rootDSE.Properties["defaultNamingContext"].Value.ToString();
            }
            
