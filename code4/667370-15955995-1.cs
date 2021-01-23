    foreach (ListItem item in cblCRMStatus.Items)
    {
        if (item.Value == "5")
        {
            item.Selected = true;
            item.Enabled = false;
        }
    }
