    FacebookUser user = FacebookLogin.CheckLogin();
    if (user != null)
    {
	Response.Write("&lt;p&gt;" + user.Email);
	Response.Write("&lt;p&gt;" + user.FirstName);
	Response.Write("&lt;p&gt;" + user.LastName);
    }
