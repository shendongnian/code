    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.getName();
        }
    }
    private void getName()
    {
        DataView dv = (DataView)SqlDataSource_CompID.Select(DataSourceSelectArguments.Empty);
        DataRowView drv = dv[0];
        Session["CompID"] = drv["CompanyID"].ToString();
    }
