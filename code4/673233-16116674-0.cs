    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           if(Request.QueryString["pid"]!=null && Session["pid"]!=null)
            pid = Convert.ToInt32(Request.QueryString["pid"]); 
            DataBind(true);
            PopulateTestSuiteList();
        }
        TestSuitesDataList.ItemCommand += new RepeaterCommandEventHandler(this.Item_Command);
    }
