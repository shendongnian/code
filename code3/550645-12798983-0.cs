	public bool AccessException;
	protected void Page_Load(object sender, EventArgs e)
	{
		UpdateNavigation();
		if (!HasAccess() && !AccessException)
		{
			Response.Redirect("~/NoAccess.aspx", true);
		}
	}
	/// <summary>
	/// Check domain group membership to make sure the user is allowed to use the web site; redirect if not.
	/// </summary>
	/// <returns>True if the user has access to the site</returns>
	private bool HasAccess()
	{
		if (Page.Cache["hasAccess"] == null)
		{
			List<string> userDomainGroups = Common.GetUserDomainGroups(Request.LogonUserIdentity);
			string permittedGroups = ConfigurationManager.AppSettings["AllowedGroups"];
			Page.Cache["hasAccess"] = userDomainGroups.Where(permittedGroups.Contains).Count() != 0; ;
		}
		return (bool)Page.Cache["hasAccess"];
	}
