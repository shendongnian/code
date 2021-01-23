    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        dynamic data = new[] {
           new { ID = 1, Name = "Name1"},
           new { ID = 2, Name = "Name2"},
           new { ID = 3, Name = "Name3"},
           new { ID = 4, Name = "Name4"},
           new { ID = 5, Name = "Name5"}
       };
        RadGrid1.DataSource = data;
    }
    protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        GridEditableItem item = e.Item as GridEditableItem;
        UpdateLogic(item);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridEditableItem item in RadGrid1.EditItems)
        {
            UpdateLogic(item);
            item.Edit = false;
        }
        RadGrid1.Rebind();
    }
    protected void UpdateLogic(GridEditableItem item)
    {
        // perform your update logic here
    }
