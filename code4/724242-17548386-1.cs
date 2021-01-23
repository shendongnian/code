    string item = (string)listBox1.SelectedItem;
    
    if(!listOfGroups.ContainsKey((string)listBox2.SelectedItem))
        listOfGroups.Add((string)listBox2.SelectedItem,new List<string>());
    ((List<string>)listOfGroups[(string)listBox2.SelectedItem]).Add(item);
    
    listBox3.Items.Add(item);
    listBox1.Items.Remove(item);
