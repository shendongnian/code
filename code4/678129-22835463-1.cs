    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dt = new DataTable();
            MakeDataTable();
        }
        else
        {
            dt = (DataTable)ViewState["DataTable"];
        }
        ViewState["DataTable"] = dt;
    }
    private void MakeDataTable()
    {
        dt.Columns.Add("Name");
        dt.Columns.Add("Number");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        AddToDataTable();
        BindGrid();
    }
    private void AddToDataTable()
    {
        DataRow dr = dt.NewRow();
        dr["Name"] = txtName.Text;
        dr["Number"] = txtNumber.Text;
        dt.Rows.Add(dr);
    }
    private void BindGrid()
    {
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
