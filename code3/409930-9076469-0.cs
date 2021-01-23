    protected void Page_Load(object sender, EventArgs e)
    {
        if (!isPostBack || Session["DataSource"] = null)        
        {
             Ddl_Num.DataSource = SqlDataSource1;//DataSource1
             Ddl_Num.DataBind(); 
        }
    }
    protected void Btn_Click(object sender, EventArgs e)
    {
        Ddl_Num.DataSource = SqlDataSource2;//DataSource2
        Ddl_Num.DataBind();
        Session["ChangeDataSource"] = true; 
    }
