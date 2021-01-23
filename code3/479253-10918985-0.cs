            TextReader reader = new StringReader(richTextBox1.Text);
            string[] strItems = null;
            while (reader.Peek() != -1)
            {
                string nextRow = reader.ReadLine();
                if (!listView1.Items.Exists(item => item.Tag == nextRow))
                {
                   ListViewItem item = new ListViewItem();
                   item.Tag = nextRow;
                   strItems = nextRow .Split("-".ToCharArray());
                   item.Text = strItems[0].ToString();
                   item.SubItems.Add(strItems[1].ToString());
                   item.SubItems.Add(strItems[2].ToString());
                   item.SubItems.Add(strItems[3].ToString());
                   item.SubItems.Add(strItems[4].ToString());
                   listView1.Items.Add(item);
                }
            }
