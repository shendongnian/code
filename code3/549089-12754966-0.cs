    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
       {
           MyList.DataSource = getDataFromDB();
           MyList.DataBind();
       }
    }
