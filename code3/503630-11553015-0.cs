    e.Item = new ListViewItem(patientNo);    
    if (status.Equals("Yes"))
    {
        e.Item.ForeColor = Color.Red;
    }
    
    e.Item.SubItems.Add(lastName);
    
    e.Item.SubItems.Add(firstName);
    e.Item.SubItems.Add(middleInitial + ".");
    e.Item.SubItems.Add(age));
    e.Item.SubItems.Add(address + ".");
    e.Item.SubItems.Add(type);
    e.Item.SubItems.Add(status);   
