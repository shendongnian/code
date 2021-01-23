    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        dynamic data = new[] {
            new { ID = 1, Name ="Name1"},
            new { ID = 2, Name = "Name2"},
            new { ID = 3, Name = "Name3"},
             new { ID = 4, Name = "Name4"},
            new { ID = 5, Name = "Name5"}
        };
        RadGrid1.DataSource = data;
    }
    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "insertandnew")
        {
            // Perform Your Insert operation
            e.Canceled = true;
            //Set insertmonde once again
            RadGrid1.MasterTableView.IsItemInserted = true;
            RadGrid1.Rebind();
        }
        else if (e.CommandName == "insertandclose")
        {
            // Perform Your Insert operation
            RadGrid1.MasterTableView.IsItemInserted = false;
            RadGrid1.Rebind();
        }
    }
