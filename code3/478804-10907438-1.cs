    private void button1_Click(object sender, EventArgs e) 
    {
        string[] lines = richTextBox1.Lines;
     
        // Not sure about the exact Items.Contains() and item.Text usage, but that's the idea
        foreach (string line in lines.Distinct().Where(line => 
            !listView1.Items.Contains(item => line == item.Text)))
        { 
            string[] items = line.Split('-'); 
            listView1.Items.Add(new ListViewItem(items)); 
        } 
    } 
