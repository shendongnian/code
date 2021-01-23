    foreach(ListItem li in ListBox2.Items.Where(x => x.Selected)) {
        ListItem liNew = new ListItem(li.Text, li.Value);
        ListBox1.Items.Add(liNew);
        ListBox2.Items.Remove(li);
    }
