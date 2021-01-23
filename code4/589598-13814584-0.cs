    private string GetNetbiosDomainName(string dnsDomainName)
        {
            string netbiosDomainName = string.Empty;
    
            DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
    
            string configurationNamingContext = rootDSE.Properties["configurationNamingContext"][0].ToString();
    
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://cn=Partitions," + configurationNamingContext);
    
            DirectorySearcher searcher = new DirectorySearcher(searchRoot);
            searcher.SearchScope = SearchScope.OneLevel;
            searcher.PropertiesToLoad.Add("netbiosname");
            searcher.Filter = string.Format("(&(objectcategory=Crossref)(dnsRoot={0})(netBIOSName=*))", dnsDomainName);
    
            SearchResult result = searcher.FindOne();
    
            if (result != null)
            {
                netbiosDomainName = result.Properties["netbiosname"][0].ToString();
            }
    
            return netbiosDomainName;
        }
