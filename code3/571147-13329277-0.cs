    foreach (ListViewItem item in listView1.Items)
    {
        if (item.Checked)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add(textBox1.Text);
            lvi.SubItems.Add(textBox2.Text);
            lvi.SubItems.Add(textBox3.Text);
            lvi.SubItems.Add(textBox4.Text);
            foreach (ListViewSubItem subItem in item.SubItems)
            {
                lvi.SubItems.Add(subItem);
            }
            listView2.Items.Add(lvi);
        }
    }
