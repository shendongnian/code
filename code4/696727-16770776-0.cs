    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind("");
        }
        else
        {
            Bind(tb.Text);
        }
        SetFocus(tb);
    }
    private void Bind(string searchPattern)
    {
        if (searchPattern == "")
            searchPattern = "*";
        DirectoryInfo dir = new DirectoryInfo(MapPath("~/ajax _main/testpages/images/"));
        FileInfo[] files = dir.GetFiles("*" + searchPattern + "*.*");
        ArrayList list = new ArrayList();
        foreach (FileInfo oItem in files)
        {
            if (oItem.Extension == ".jpg" || oItem.Extension == ".jpeg" || oItem.Extension == ".gif")
                list.Add(oItem);
        }
        DataList1.DataSource = list;
        DataList1.DataBind();
    }
