    private void button1_Click(object sender, EventArgs e)
    {
        string[] lines = File.ReadAllLines(richTextBox1.Text);
        foreach (string line in lines.Distinct())
        {
            listView1.Items.Add(new ListViewItem(line.Split({'-'})));
        }
    }
