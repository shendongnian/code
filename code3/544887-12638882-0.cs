    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       if (!listView1.Items[0].Selected) {
           listView1.SelectedIndices.Clear();
           listView1.Items[0].Selected = true;
       }
    }
