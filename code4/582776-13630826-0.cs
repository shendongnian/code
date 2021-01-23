    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack) Session["prev"] = Request.UrlReferrer.ToString();
    }
    protected void BackButton_Click( object sender , EventArgs e )
    {      
       if(Session["prev"] != null) Response.Redirect(previousPage);
       else ...
    }
