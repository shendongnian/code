    private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        if (e.IsSelected)
        {
            if (e.Item.Text == "1")
                textBox1.Focus();
            else
                textBox2.Focus();
        }
        listView1.Enabled = false;
    }
    private void listView1_MouseUp(object sender, MouseEventArgs e)
    {
        listView1.Enabled = true;
    }
    private void listView1_MouseLeave(object sender, EventArgs e)
    {
        listView1.Enabled = true;
    }
