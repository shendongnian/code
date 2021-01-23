	DirectoryEntry DE = new DirectoryEntry("LDAP://OU=ou_to_search_recursively", user, password);
	using (DirectorySearcher DSE = new DirectorySearcher(DE))
	{
		DSE.PageSize = 1000;
		//get only users
		DSE.Filter = "(&(objectClass=user)(objectCategory=person))";
		//search recursively
		DSE.SearchScope = SearchScope.Subtree;
		//load the properties that you want
		DSE.PropertiesToLoad.Clear();
		DSE.PropertiesToLoad.Add("distinguishedName");
		DSE.PropertiesToLoad.Add("cn");
		DSE.PropertiesToLoad.Add("other_attribute_you_might_want");
		foreach (SearchResult u in DSE.FindAll())
		{
			//check if property exists
			if (u.Properties.Contains("distinguishedName")) {
				// access property: 
				string dn = u.Properties["distinguishedName"][0].ToString();
			}
			//...
		}
	}
