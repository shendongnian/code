    private void listView1_Click(object sender, EventArgs e)
    {
         if(listView1.SelectedItems.Count > 0)
                 MessageBox.Show("You clicked " + listView1.SelectedItems[0].Text);
    }
