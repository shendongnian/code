    public void buildProjectList(string project,string type)
    {
       ListViewItem projItem = new ListViewItem(project);
       projItem.SubItems.Add(type);
       listView1.Items.Add(projItem);
    }
