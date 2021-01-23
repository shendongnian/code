    public int CurrentPage
    {
        get
        {
            // look for current page in ViewState
            object o = this.ViewState["_CurrentPage"];
            if (o == null)
                return 0;	// default to showing the first page
            else
                return (int)o;
        }
        set
        {
            this.ViewState["_CurrentPage"] = value;
        }
    }
    private void updateMessage()
    {
        PagedDataSource objpd = new PagedDataSource();
        string connStr = ConfigurationManager.ConnectionStrings["yafnet"].ConnectionString;
        SqlConnection mySQLconnection = new SqlConnection(connStr);
        if (mySQLconnection.State == ConnectionState.Closed)
        {
            mySQLconnection.Open();
        }
        SqlCommand mySqlSelect = new SqlCommand("SELECT * FROM [Comments]", mySQLconnection);
        mySqlSelect.CommandType = CommandType.Text;
        SqlDataAdapter mySqlAdapter = new SqlDataAdapter(mySqlSelect);
        DataTable table = new DataTable();
        mySqlAdapter.Fill(table);
        objpd.DataSource = table.DefaultView;
        objpd.AllowPaging = true;
        objpd.PageSize = 1;
        objpd.CurrentPageIndex = CurrentPage;
        //disable pre or next buttons if necessary
        cmdPrev.Enabled = !objpd.IsFirstPage;
        cmdNext.Enabled = !objpd.IsLastPage;
        Repeater1.DataSource = objpd;
        Repeater1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        updateMessage();
        
    }
    protected void cmdPrev_Click(object sender, EventArgs e)
    {
        // Set viewstate variable to the previous page
        CurrentPage -= 1;
        // Reload control
        updateMessage();
    }
    protected void cmdNext_Click(object sender, EventArgs e)
    {
        // Set viewstate variable to the next page
        CurrentPage += 1;
        // Reload control
        updateMessage();
    }
