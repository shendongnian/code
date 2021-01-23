    var listView1 = new ListView();
    DataTable table = new DataTable();
    foreach (ListViewItem item in listView1.Items)
    {
        table.Columns.Add(item.ToString());
        foreach (var it in item.SubItems)
             table.Rows.Add(it.ToString());
     }
