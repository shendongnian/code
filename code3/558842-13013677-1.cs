    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var dataSource = (from id in Enumerable.Range(0, 10)
                                select new { ID = id, Title = id.ToString() + " Title", Content = Guid.NewGuid().ToString() }).ToList();
            rptTabs.DataSource = dataSource;
            rptTabs.DataBind();
            rptTabsSub.DataSource = dataSource;
            rptTabsSub.DataBind();
        }
    }
    [WebMethod]
    public static void DeleteRecord(int id)
    {
        //delete record by id
    }
