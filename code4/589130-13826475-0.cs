    using (PrincipalContext localContext = new PrincipalContext(ContextType.Machine))
				{
					try
					{
						foreach (string g in groups)
						{
							using (GroupPrincipal localGroup = GroupPrincipal.FindByIdentity(localContext, IdentityType.Name, g))
							{
								foreach (Principal groupUser in localGroup.GetMembers().Where(groupUser => user.Name.Equals(groupUser.Name)))
								{
									localGroup.Members.Remove(groupUser);
									localGroup.Save();
								}
							}
						}
					}
