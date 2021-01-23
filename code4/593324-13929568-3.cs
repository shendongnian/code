    Protected void Page_load(object sender ,EventArgs e) 
    {
        if(!IsPostBack)
        {
            gridViewLinks.DataSource = GetAllLinks();
            gridViewLinks.DataBind();
        }
    }
