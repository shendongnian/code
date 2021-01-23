    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       listview1.SelectedIndexChanged -= new EventHandler(listView1_SelectedIndexChanged);
       listView1.SelectedIndices.Clear();
       listView1.Items[0].Selected = true;
       listview1.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);
    }
