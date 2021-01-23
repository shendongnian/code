    bool contains = lbName.Items.Cast<ListItem>()
        .Any(li => li.Text.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase));
    if(!contains)
    {
        lbName.Items.Add(new ListItem(txtName.Text));
    }
