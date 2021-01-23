    protected void BindDataList()
    {
        var imgDir = HttpContext.Current.Server.MapPath(string.Format(@"~/Images/{0}/", Model.Text));
        DirectoryInfo dir = new DirectoryInfo(imgDir);
        FileInfo[] files = dir.GetFiles();
        ArrayList listItems = new ArrayList();
        foreach (FileInfo info in files)
        {
            listItems.Add(info);
        }
        DataList1.DataSource = listItems;
        DataList1.DataBind();
    }
    protected void upload_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        var imgPath = HttpContext.Current.Server.MapPath(string.Format(@"~/Images/{0}/{1}", Model.Text, filename));
        
        FileUpload1.SaveAs(imgPath);
        BindDataList();
    }
    protected void newfolder_Click(object sender, EventArgs e)
    {
        var imgDir = HttpContext.Current.Server.MapPath(string.Format(@"~/Images/{0}/", Model.Text));
        //New Directory Name in string variable
        CreateDirectoryIfNotExists(imgDir);
        //Calling the function to create new directory
    }
