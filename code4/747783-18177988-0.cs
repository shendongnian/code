    protected void Page_Load(Object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             DataBindDataList();
        }
    }
    private void DataBindDataList()
    {
        var dataSource = getSource(); // some data
        DataList1.DataSource = dataSource;
        DataList1.DataBind();
    }
