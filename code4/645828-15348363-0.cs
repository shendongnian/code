	void Main()
	{
		string groupName = "somegroup";
		string domainName = "somedomain";
				
		using(PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName))
		{
			using(GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, groupName))
			{
				var a = from x in grp.GetMembers(true) select new {x.SamAccountName, x.DisplayName,};
				var users = a.Distinct();
			}
		}
	}
