    public void buildProjectList(string project, string type)
    {
        ListViewItem projItem = new ListViewItem(project+"-"+type);
        listView1.Items.Add(projItem);
    }
