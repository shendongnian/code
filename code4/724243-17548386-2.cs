    private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        listBox3.Items.Clear();
        if (!listOfGroups.ContainsKey((string)listBox2.SelectedItem))
            listOfGroups.Add((string)listBox2.SelectedItem, new List<string>());
        
        listBox3.Items.AddRange(listOfGroups[(string)listBox2.SelectedItem].ToArray());
        
        List<string> list = listOfAllItems.Where(a => !listBox3.Items.Contains(a)).ToList();
        listBox1.Items.Clear();
        listBox1.Items.AddRange(list.ToArray());
    }
