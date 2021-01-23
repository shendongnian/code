    private void button1_Click(object sender, EventArgs e) 
    { 
        string[] lines = File.ReadAllLines(richTextBox1.Text); 
     
        // Not sure about the exact Items.Contains() and item.Text usage, but that's the idea
        foreach (string line in lines.Distinct().Where(line => 
            !listView1.Items.Contains(item => line == item.Text)))
        { 
            string[] items = reader.ReadLine().Split('-'); 
            listView1.Items.Add(new ListViewItem(items)); 
        } 
    } 
