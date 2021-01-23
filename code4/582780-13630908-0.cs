    protected void Page_Load(object sender, EventArgs e)
    {
     if(!IsPostBack)
     {   
      if( Request.UrlReferrer != null)
        {
            previousPage = Request.UrlReferrer.ToString();
            CrossSideScriptingErrorCheck.Text = previousPage;
        }  
      }
    }
