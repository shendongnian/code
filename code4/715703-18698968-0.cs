    protected void Page_Load(object sender, EventArgs e)
    {
       if (Page.IsPostBack)
       {
          targetASPxGridView.DataBind();
       }
    
       // Rest of code
    }
