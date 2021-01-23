    public static bool IsInRoles(this IPrincipal user, List<string> roles)
    {
		bool output = false;
		foreach (string role in roles)
		{
			output = user.IsInRole(role);
		}
		return output;
	}
