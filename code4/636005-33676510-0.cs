        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Scroll Control", 100);
            for(int i = 0; i < 100; i++)
            {
                listView1.Items.Add(string.Format("Item #{0:000}", i));
            }
            timer1.Interval = 1000;
            timer1.Start();
        }
        private int newItem = 10;
        private bool inspectingList = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            listView1.Items.Add(string.Format("Item #{0:000}", newItem));
            newItem += 10;
            if (!inspectingList)
            {
                listView1.Items[listView1.Items.Count - 1].EnsureVisible();
            }
            listView1.Refresh();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            inspectingList = true;
            if (listView1.SelectedIndices.Count > 0)
            {
                listView1.Items[listView1.SelectedIndices[0]].EnsureVisible();
            }
        }
        private void listView1_Leave(object sender, EventArgs e)
        {
            inspectingList = false;
        }
