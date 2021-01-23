    if(!IsPostBack)
    {
       if( Request.UrlReferrer != null)
        {
            previousPage = Request.UrlReferrer.ToString();
            CrossSideScriptingErrorCheck.Text = previousPage;
        }
    }
