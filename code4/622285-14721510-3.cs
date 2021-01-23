    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDataList();
        }
    }
    protected void BindDataList()
    {
        DirectoryInfo dir = new DirectoryInfo(MapPath("Images"));
        FileInfo[] files = dir.GetFiles();
        ArrayList listItems = new ArrayList();
        foreach (FileInfo info in files)
        {
            listItems.Add(info);
        }
        dtlist.DataSource = listItems;
        dtlist.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(fileupload1.PostedFile.FileName);
        fileupload1.SaveAs(Server.MapPath("Images/" + filename));
        BindDataList();
    }
