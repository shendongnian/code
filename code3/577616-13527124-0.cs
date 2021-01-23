    using System.DirectoryServices;
    
    string[] RetProps = new string[] { "SamAccountName", "DisplayName" };
                    //IDictionary<string, string> users = new Dictionary<string, string>();
    List<string[]> users = new List<string[]>();
    
               foreach (SearchResult User in GetAllUsers("YourDomain", RetProps))
               {
                DirectoryEntry DE = User.GetDirectoryEntry();
                try
                   {
                    users.Add(new string[]{DE.Properties["SamAccountName"][0].ToString(), DE.Properties["DisplayName"][0].ToString()});
                   }
                   catch
                   {
                   }
                }
    
    
        internal static SearchResultCollection GetAllUsers(string DomainName, string[] Properties)
        {
          DirectoryEntry DE = new DirectoryEntry("LDAP://" + DomainName);
          string Filter = "(&(objectCategory=organizationalPerson)(objectClass=User))";
          DirectorySearcher DS = new DirectorySearcher(DE);
          DS.PageSize = 10000;
          DS.SizeLimit = 10000;
          DS.SearchScope = SearchScope.Subtree;
          DS.PropertiesToLoad.AddRange(Properties); DS.Filter = Filter;
          SearchResultCollection RetObjects = DS.FindAll();
          return RetObjects;
        }
      }
    }
