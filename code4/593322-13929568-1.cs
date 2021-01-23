    Protected void Page_load(object sender ,EventArgs e) 
    {
        if(!IsPostBack)
        {
            gridView1.DataSource = getAllUsers();
            gridView1.DataBind();
        }
    }
