    for(int i = ListBox2.Items.Count; --i >= 0;) {
        ListItem li = ListBox2.Items[i];
    
        if(li.Selected) {
            ListItem liNew = new ListItem(li.Text, li.Value);
            ListBox1.Items.Add(liNew);
            ListBox2.Items.RemoveAt(i);
        }
    }
