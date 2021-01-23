    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            ListViewItem item = listView1.SelectedItems[0];
            if (item != null)
            {
                EmpIDtextBox.Text = item.SubItems[0].Text;
                EmpNametextBox.Text = item.SubItems[1].Text;
            }
        }
        else
        {
            EmpIDtextBox.Text = string.Empty;
            EmpNametextBox.Text = string.Empty;
        }
    }
