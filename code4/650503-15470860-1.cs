    private void button1_Click(object sender, EventArgs e)
    {
        Add_Order add = new Add_Order();
        add.ShowDialog();
        ListViewItem item = new ListViewItem();
        List<string> data = add.GetData();
        item.Text = data[0];
        item.SubItems.Add(data[1]);
        item.SubItems.Add(data[2]);
        item.SubItems.Add(data[3]);
        item.SubItems.Add(data[0]);
        listView2.Items.Add(item);
    }
