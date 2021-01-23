    protected void Page_Load(object sender, EventArgs e)
    {
        lstview = taview.GetData().ToList();
        GridAllStore.DataSource = lstview; 
        GridAllStore.DataBind();
    }
