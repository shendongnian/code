	public bool IsInDomainRole(string role)
	{
		var regex = new Regex("[^\\\\]+$");
		string name = this.Name ?? string.Empty;
		string domainRole = regex.Replace(name, role);
		return this.IsInRole(domainRole);
	}
