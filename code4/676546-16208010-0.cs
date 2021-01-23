    protected void BindDataList()
    {
        var imgPath = HttpContext.Current.Server.MapPath(string.Format(@"~/Images/{0}/", Model.Text));
        DirectoryInfo dir = new DirectoryInfo(MapPath(@"~/Images/"+Model.Text+"/"));
        FileInfo[] files = dir.GetFiles();
        ArrayList listItems = new ArrayList();
        foreach (FileInfo info in files)
        {
            listItems.Add(info);
        }
        DataList1.DataSource = listItems;
        DataList1.DataBind();
    }
