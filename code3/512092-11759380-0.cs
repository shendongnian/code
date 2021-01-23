        ListViewItem lvItem;
        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
        {
            lvItem = new ListViewItem();
            lvItem.SubItems.Add(row.Cells["ID"].Value.ToString());
            lvItem.SubItems.Add(row.Cells["Item"].Value.ToString());
            lvItem.SubItems.Add(row.Cells["Cost"].Value.ToString());
            lvItem.SubItems.Add(row.Cells["Manufacturer"].Value.ToString());
            lvItem.SubItems.Add(row.Cells["Quanlity"].Value.ToString());
            // ...
        }
