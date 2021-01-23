       private List<string> getAnyDirectoryEntryPropertyValue(string userPrincipalName, string propertyToSearchFor)
        {
            List<string> returnValue = new List<string>();
            try
            {
                int index = userPrincipalName.IndexOf("@");
                string originatingServer = userPrincipalName.Remove(0, index + 1);
                string path = "LDAP://" + originatingServer; //+ @"/" + distinguishedName;
                DirectoryEntry objRootDSE = new DirectoryEntry(path, PSUsername, PSPassword);
                var objSearcher = new System.DirectoryServices.DirectorySearcher(objRootDSE);
                objSearcher.Filter = string.Format("(&(UserPrincipalName={0}))", userPrincipalName);
                SearchResultCollection properties = objSearcher.FindAll();
                ResultPropertyValueCollection resPropertyCollection = properties[0].Properties[propertyToSearchFor];
                foreach (string resProperty in resPropertyCollection)
                {
                    returnValue.Add(resProperty);
                }
            }
            catch (Exception ex)
            {
                returnValue.Add(ex.Message);
                throw;
            }
            return returnValue;
        }
