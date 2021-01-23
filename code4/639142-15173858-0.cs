    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listView = sender as ListView;
            
        if (listView.SelectedItems.Count == 0) return;
         
        textBox1.Text = listView.SelectedItems[0].SubItems[0].Text;
        textBox2.Text = listView.SelectedItems[0].SubItems[1].Text;
    }
