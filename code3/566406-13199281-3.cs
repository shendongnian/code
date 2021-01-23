    if (EditedName != null && EditedName != string.Empty)
    {                
        ContactNames[SelectedIndex] = EditedName;
        EditedName = string.Empty;
    }
    else if (ContactName!=null && ContactName != string.Empty)
    {
        ContactNames.Add(ContactName);
        ContactName = string.Empty;
    }
