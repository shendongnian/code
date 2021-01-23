    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(CommonFunctions.GetAppDBConnection(Constants.AppID, Constants.TMDDBConnection));
        con.Open();
        SqlCommand mycommand = new SqlCommand("select * from MSUnit", con);
        SqlDataAdapter adp =new   SqlDataAdapter(mycommand);
        DataSet ds =new DataSet();
        adp.Fill(ds);
        ddlTransactionCategory.DataSource = ds;
        ddlTransactionCategory.DataTextField = "categoryCode";
        ddlTransactionCategory.DataValueField = "OrgID";
        ddlTransactionCategory.DataBind();
        mycommand.Connection.Close();
        mycommand.Connection.Dispose();
    }
