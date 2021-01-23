     private string previousPage = string.Empty;
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if( Request.UrlReferrer != null)
            {
                previousPage = Request.UrlReferrer.ToString();
                CrossSideScriptingErrorCheck.Text = previousPage;
            }
        }  
    }
    protected void BackButton_Click( object sender , EventArgs e )
    {      
       Response.Redirect(previousPage);
    }
