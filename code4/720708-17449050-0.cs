    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        foreach (GridColumn column in RadGrid1.MasterTableView.Columns)
        {
            // If you used ClientSelectColumn then below code is not worked For that you have to put condition
            //if(column.ColumnType  == "GridBoundColumn")
            int TotalNullRecords = (from item in RadGrid1.MasterTableView.Items.Cast<GridDataItem>()
                                    where string.IsNullOrWhiteSpace(item[column.UniqueName].Text) ||
                                    item[column.UniqueName].Text == "&nbsp;"
                                    select item).ToList().Count;
            if (TotalNullRecords == RadGrid1.MasterTableView.Items.Count)
            {
                RadGrid1.MasterTableView.Columns.FindByUniqueName(column.UniqueName).Visible = false;
            }
        }
    }
