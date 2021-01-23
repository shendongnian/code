	public static class IPrincipalExtensions
	{
            private static _adminName = "Administrator";
		public static bool IsAnonymous(this IPrincipal instance)
		{
			return (instance == null);
		}
		public static bool IsAdminOrInRole(this IPrincipal instance, string role)
		{
			if (instance == null
				|| instance.Identity == null
				|| !instance.Identity.IsAuthenticated)
			{
				return false;
			}
			bool result = instance.IsInRole(role)
						  || instance.IsInRole(IPrincipalExtensions._adminName));
			return result;
		}
	}
