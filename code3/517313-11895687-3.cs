    private void button6_Click(object sender, EventArgs e)
        {
            ListViewItem listviewitem;
            listviewitem = new ListViewItem("John");
            listviewitem.SubItems.Add("Smith");
            listviewitem.SubItems.Add("kaya");
            listviewitem.SubItems.Add("bun");
            this.listView1.Items.Add(listviewitem);
            //listView1.FullRowSelect = true;
            listView1.Items[0].Selected = true;
            MessageBox.Show("You clicked " + listView1.SelectedItems[0].Text);
    }
