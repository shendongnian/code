    public Collection<software_user> GetUsersFromAD(String adConnectionString)
		{
				var users = new Collection<software_user>();
				using (var directoryEntry = new DirectoryEntry(adConnectionString))
				{
						var directorySearcher = new DirectorySearcher(directoryEntry);
						directorySearcher.Filter = "(&(objectClass=user))";
						var propertiesToLoad = new[] 
						{ 
							 "SAMAccountName", 
							 "displayName", 
							 "givenName", 
							 "sn", 
							 "mail", 
							 "userAccountControl", 
							 "objectSid" 
						};
						directorySearcher.PropertiesToLoad.AddRange(propertiesToLoad);
						foreach (SearchResult searchEntry in directorySearcher.FindAll())
						{
								var userEntry = searchEntry.GetDirectoryEntry();
								var ldapUser = new software_user();
								ldapUser.User_name = NullHandler.GetString(userEntry.Properties["displayName"].Value);
								if (string.IsNullOrEmpty(ldapUser.User_name))
									 continue;
								ldapUser.User_name = NullHandler.GetString(userEntry.Properties["SAMAccountName"].Value);
								ldapUser.email = NullHandler.GetString(userEntry.Properties["mail"].Value);
								ldapUser.user_shortname = NullHandler.GetString(userEntry.Properties["givenName"].Value);
								var userAccountControl = (int)userEntry.Properties["userAccountControl"].Value;
								//ldapUser.IsActive = (userAccountControl & UF_ACCOUNTDISABLE) != UF_ACCOUNTDISABLE;
								SecurityIdentifier sid = new SecurityIdentifier((byte[])userEntry.Properties["objectSid"][0], 0).Value;
		-->						NTAccount account = (NTAccount) sid.Translate(typeof(NTAccount));
		-->						ldapUser.User_name = account.ToString();
								//ldapUser.SId = sid;
								users.Add(ldapUser);
						 }
				}
				return users;
		}
