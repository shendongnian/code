    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sender != null)
        {
            ListView lv = (ListView)sender;
            if ((lv.FocusedItem != null) && (lv.FocusedItem.SubItems.Count >= 4))
            {
                textBox2.Text = lv.FocusedItem.SubItems[3].Text;
                textBox3.Text = lv.FocusedItem.SubItems[0].Text;
            }
        }
    }
