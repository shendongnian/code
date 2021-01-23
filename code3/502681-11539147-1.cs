    protected void RadGrid3_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        dynamic data = new[] {
                new { ID = 1, Name ="Name1"},
                new { ID = 2, Name = "Name2"},
                new { ID = 3, Name = "Name3"}
            };
        RadGrid3.DataSource = data;
    }
    protected void RadGrid3_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            CheckBox Chk1 = item.FindControl("Chk1") as CheckBox;
            CheckBox Chk2 = item.FindControl("Chk2") as CheckBox;
            // default first check box will be checked
            Chk1.Checked = true;
            Chk1.Attributes.Add("onclick", "checkUncheckManage(this,'" + Chk2.ClientID+ "')");
            Chk2.Attributes.Add("onclick", "checkUncheckManage(this,'" + Chk1.ClientID + "')");
        }
    }
