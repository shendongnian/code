    DataTable dtZeitplan = new DataTable();
    foreach (ColumnHeader chZeitplan in lvZeitplan.Columns)
    {
        dtZeitplan.Columns.Add(chZeitplan.Text);
    }
    foreach (ListViewItem item in lvZeitplan.Items)
    {
        DataRow row = dtZeitplan.NewRow();
        for(int i = 0; i < item.SubItems.Count; i++)
        {
            row[i] = item.SubItems[i].Text;
        }
        dtZeitplan.Rows.Add(row);
    }
