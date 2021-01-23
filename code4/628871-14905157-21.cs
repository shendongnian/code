       private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var text = Regex.Split(textBox1.Text, @"\D+");
            var t = text.Select(c => decimal.Parse(c)).Sum(); //<--Get all the total
            foreach (var i in text)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i;
                item.SubItems.Add(((decimal.Parse(i) / t) * 100).ToString());
                listView1.Items.Add(item);
            }
            //decimal total = listView1.Items.Cast<ListViewItem>()
            //                         .Select(c => decimal.Parse(c.SubItems[1].Text))
            //                         .Sum();
            //ListViewItem item2 = new ListViewItem();
            //item2.Text = "Total:";
            //item2.SubItems.Add(total.ToString("#,#0.00"));
            //listView1.Items.Add(item2);
        }
