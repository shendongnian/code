    private void button1_Click(object sender, EventArgs e)
    {
        TextReader reader = new StringReader(richTextBox1.Text);
        string[] strItems = null;
        foreach (ListViewItem item in listView1.Items)
        {
            strItems = reader.ReadLine().Split("-".ToCharArray());
            if (ListView1.FindItemWithText(strItems[0].ToString()) != null)
            {
                item.Text = strItems[0].ToString();
                item.SubItems.Add(strItems[1].ToString());
                item.SubItems.Add(strItems[2].ToString());
                item.SubItems.Add(strItems[3].ToString());
                item.SubItems.Add(strItems[4].ToString());
                listView1.Items.Add(item);
            }
        }
    }
