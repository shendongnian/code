    foreach (ListViewItem item in lsvTSEntry.Items)
    {
        item.FindControl("myLabel").Visible = false;
        item.FindControl("myDropdownList").Visible = false;
    }
