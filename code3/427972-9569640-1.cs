    public DataTable GetData()
    {
        DataTable Dt = new DataTable();
        DataColumn DC = new DataColumn("Test");
        Dt.Columns.Add(DC);
    
        DataRow Dr = Dt.NewRow();
        Dr["Test"] = "1";
        Dt.Rows.Add(Dr);
        return Dt;//.Rows[0]["test"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        grd.DataSource = GetData();
        grd.DataBind();
    }
----------
