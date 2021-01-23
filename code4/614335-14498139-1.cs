    private void BindTable(DataTable table)
    {
        lvItemList.Clear();
        foreach (DataRow row in table.Rows)
        {
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = row["ColumnName"].ToString();
            lvItemList.Items.Add(lvItem);
            // Or in a one-liner
            //lvItemList.Items.Add(row["ColumnName"].ToString();
        }
    }
