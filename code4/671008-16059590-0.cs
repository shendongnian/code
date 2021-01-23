    private DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dt= new DataTable();
            dt.Columns.Add("First", typeof(String));
            dt.Columns.Add("Last", typeof(String));
            dt.Columns.Add("Email", typeof(String));
            dt.Columns.Add("Phone", typeof(String));
            Session["TempTable"] = dt;
            grid.DataSource = dt;
        }
        else
        {
            dt = (DataTable)Session["TempTable"];
            grid.DataSource = dt;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        dt = (DataTable)Session["TempTable"]; // Fetching datatable from session
        DataRow dr = dt.NewRow(); // Adding new row to datatable
        dr[0] = "Jenny";
        dr[1] = "LastName";
        dr[2] = "Jenny@hotmail.com";
        dr[3] = "867-5309";
        dt.Rows.Add(dr);
        Session["TempTable"] = dt;   // update datatable in session
        grid.DataSource = dt;   // updated datatable is now new datasource
        grid.DataBind();        // calling databind on gridview
    }
