    var toAdd = CheckBoxList1.Items.Cast<ListItem>()
                             .Where(li => li.Selected 
                                       && !CheckBoxList2.Items.Contains(li));
    foreach(ListItem li in toAdd)
    {
        CheckBoxList2.Items.Add(li);
    }
