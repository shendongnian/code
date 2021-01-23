    void AddMenuItems(ToolStripItemCollection itemCollection, DataView view)
    {
        foreach (DataRowView rowView in view)
            itemCollection.Add(MakeMenuItem(rowView.Row));
    }
    ToolStripItem MakeMenuItem(DataRow row)
    {
        var item = new ToolStripMenuItem((string)row["Name"]);
        item.Tag = row;
        item.Click += new EventHandler(MenuItem_Click);
        return item;
    }
    void MenuItem_Click(object sender, EventArgs e)
    {
        var row = ((ToolStripItem)sender).Tag as DataRow;
        MessageBox.Show((string)row["HelpText"]);
    }
