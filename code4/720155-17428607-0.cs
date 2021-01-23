    protected void Page_Load(object sender, EventArgs e)
    {
        // Always get the query string no matter how the user go to this page
        string query_string = Request.QueryString["GUID"].ToString();
        // Only store the query string in Session if there is nothing in Session for it
        if(null == Session["GUID"])
        {
            Session["GUID"] = query_string;
        }
        if (!this.IsPostBack)
        {
            Label_Error.Visible = false;
        }
        // Always check to see if the query string value matches what is in Session
        string GUID = "";
        try
        {
            GUID = Session["GUID"].ToString();
        }
        catch (Exception)
        {
            Session.Abandon();
            Response.Redirect("CheckOutErrorPage.htm");
            return;
        }
        if (GUID.Equals(Request.QueryString["GUID"].ToString()) == false)
        {
            Session.Abandon();
            Response.Redirect("CheckOutErrorPage.htm");
        }
