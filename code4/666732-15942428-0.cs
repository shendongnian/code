    foreach (DataRow dataRow in dt.Rows) {
        ListViewItem item = new ListViewItem(dataRow[0].ToString());
        for (int i = 1; i < dt.Columns.Count; i++) {
            item.SubItems.Add(dataRow[i].ToString());
        }
        listView.Items.Add(item);
    }
