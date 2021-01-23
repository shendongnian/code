    foreach (ListItem item in control.Items)
    {
        if (item.Value.Trim().Equals(selectedValue.Trim()))
        {
            item.Selected = true;
        }
    }
