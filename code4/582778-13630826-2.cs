    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack) Session["prev"] = Request.UrlReferrer.ToString();
        if(Session["prev"] == null) {some code that disables the back button goes here!}
    }
    protected void BackButton_Click( object sender , EventArgs e )
    {      
       Response.Redirect(Session["prev"] as string);
    }
