    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    static private DataView dvReports;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // i am assuming that you are binding the gridview on page_load
            // you can use the same on a button click event too
            dvReports = new DataView(Ob.DataTableOther);
            BindGridView();
        }
    }
    
    protected void grdReport_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
    
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            dvProducts.Sort = sortExpression + DESCENDING;
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            dvProducts.Sort = sortExpression + ASCENDING;
        }
        BindGridView();
    }
    
    private void BindGridView()
    {
        GridView1.DataSource = dvReports
        GridView1.DataBind();
    }
    
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
    
            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }
