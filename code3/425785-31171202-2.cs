    protected void Page_Load(object sender, EventArgs e)
    {
        //No need to check IsPostBack if your action is the same either way.
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
            //Note: Using CompleteRequest() over Response.End() is significantly quicker
            //This is because it avoids raising the ThreadAbortException.
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            //So if you use CompleteRequest(), you want the return statement after.
            //Unless you wrap the rest of the Page_Load logic in an else statement, like the alternate solution below            
            return;
        }
        //All other Page_Load logic
    }
