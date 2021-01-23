    ListView listView1 = new ListView();
    listView1.View = View.Details;
    listView1.LabelEdit = true;
    listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
    listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
    listView1.Items.AddRange(new ListViewItem[]{"",""});
    listView1.Items.AddRange(new ListViewItem[]{"",""});
    .
    . (how many items you want to edit)
