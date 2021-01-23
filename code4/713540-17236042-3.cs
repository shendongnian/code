    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("flag", typeof(string));
        dt.Rows.Add(1, "true");
        dt.Rows.Add(2, "true");
        dt.Rows.Add(3, "false");
        RadGrid1.DataSource = dt;
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            DataRowView dr = item.DataItem as DataRowView; // Convert DataItem into Your Assigned Object
            (item.FindControl("CheckBox1") as CheckBox).Checked = GetBoolValueFromString(Convert.ToString(dr["flag"]));
        }
    }
    protected bool GetBoolValueFromString(string strFlag)
    {
        bool flag = false;
        bool.TryParse(strFlag, out flag);
        return flag;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
        {
            if ((item.FindControl("CheckBox1") as CheckBox).Checked)
            {
                string strID = item["ID"].Text; // Get selected Checkbox's ID Field Value
            }
        }
    }
    
