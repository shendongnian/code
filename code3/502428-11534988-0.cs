    protected void Page_Init(object sender, EventArgs e)
    {
    	if (Session["master"] != null)
    	{ }
    	else
    	{
    		Response.Redirect("login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
    	}
    }
