    List<ListItem> toRemove = new List<ListItem>();
    
    foreach(ListItem li in ListBox2.Items) {
        if(li.Selected) {
            ListItem liNew = new ListItem(li.Text, li.Value);
            ListBox1.Items.Add(liNew);
            toRemove.Add(li);
        }
    }
    
    foreach(ListItem li in toRemove) {
        ListBox2.Items.Remove(li);
    }
