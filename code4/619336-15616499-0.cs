            public static string GetNameForGuidasd(string objectGuid, string targetAttribute, string propertyToQuery, DirectoryEntry searchRoot)
            {
                DirectoryEntry schemaContainer = new DirectoryEntry("LDAP://cn=schema,cn=configuration,DC=xx,DC=xx");
                string attributeName = null;
                DirectorySearcher searcher = new DirectorySearcher(schemaContainer);
                searcher.SearchScope = SearchScope.OneLevel;
                string filter = String.Format("(&({0}={1}))", propertyToQuery, BuildFilterOctetString(objectGuid));
                searcher.Filter = filter;
                using (searcher)
                {
                    var result = searcher.FindOne();
                    if (result != null)
                    {
                        attributeName = (string)result.Properties[targetAttribute][0];
                    }
                }
            }
    
            private static string BuildFilterOctetString(string objectGuid)
            {
                System.Guid guid = new Guid(objectGuid);
                byte[] byteGuid = guid.ToByteArray();
                string queryGuid = "";
                foreach (byte b in byteGuid)
                {
                    queryGuid += @"\" + b.ToString("x2");
                }
                return queryGuid; 
            }
