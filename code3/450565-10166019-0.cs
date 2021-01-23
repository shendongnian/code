    var items = //listBox1.Items;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        listBox1.Items.Clear();
        foreach (object s in items)
        {
            if (s.ToString().Contains("hockey"))
                listBox1.Items.Add(s);
        }
        if (listBox1.Items.Count > 0)
            listBox1.SelectedIndex = 0;
    }
