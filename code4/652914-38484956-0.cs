	public partial class ApplicationUser
	{
		[ToLower, RegexReplace(@"[^a-z0-9_]")]
		public virtual string UserName { get; set; }
	}
	
	// Then to preform mutation
	var user = new ApplicationUser() {
		UserName = "M@X_speed.01!"
	}
	
	new MutationContext<ApplicationUser>(user).Mutate();
	
