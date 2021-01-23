        private void button1_Click(object sender, EventArgs e)
        {
            List<Numbers> list = new List<Numbers>();
            listView1.Items.Clear();
            var text = Regex.Split(textBox1.Text, @"\D+");
            foreach (var i in text)
            {
                list.Add(new Numbers
                {
                    oneColumn = decimal.Parse(i),
                    twoColumn = (decimal.Parse(i) / 15)
                });
                ListViewItem item = new ListViewItem();
                item.Text = i;
                item.SubItems.Add((decimal.Parse(i) / 15).ToString());
                listView1.Items.Add(item);
            }
            decimal mul = list.Sum(c => c.twoColumn)*100;
            ListViewItem item2 = new ListViewItem();
            item2.Text = "Total:";
            item2.SubItems.Add(mul.ToString("#,#0.00"));
            listView1.Items.Add(item2);
        }
