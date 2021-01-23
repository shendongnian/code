	class Program
	{
		static void Main(string[] args)
		{
			// Create the context for the principal object. 
			PrincipalContext ctx = new PrincipalContext(ContextType.Machine);
			UserPrincipal u = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, "Administrator");
			Console.WriteLine(String.Format("Administrator is enable: {0}", u.Enabled));
		}
	}
