	void Main()
	{
		string groupName = "somegroup";
		string domainName = "somedomain";
	
		using(PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName))
		{
			using(GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, groupName))
			{
				var a = from x in grp.GetMembers(true) select new {x.SamAccountName};
				var users = a.Distinct();
				foreach (var SAMID in users)
				{
					using(UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, SAMID))
					{
						Console.WriteLine("{0}, {1}, {2}",usr.SamAccountName, usr.DisplayName, usr.EmailAddress);
					}
				}
				
			}
		}
	}
