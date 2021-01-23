        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(textBox2.Text);
            item.SubItems.Add(textBox3.Text);
            item.SubItems.Add(textBox4.Text);
            listView1.Items.Add(item);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    
       
