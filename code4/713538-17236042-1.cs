    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        dynamic data = new[] {
            new { ID = 1, flag ="true"},
            new { ID = 2, flag = "false"},
            new { ID = 3, flag ="true"},
             new { ID = 4, flag = "false"},
            new { ID = 5, flag = "false"}
        };
        RadGrid1.DataSource = data;
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            bool flag = false;
            if (bool.TryParse(Convert.ToString(item.GetDataKeyValue("flag")), out flag))
            {
                (item["flag"].Controls[0] as CheckBox).Checked = flag;
            }
        }
    }
