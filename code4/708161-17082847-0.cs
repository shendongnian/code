    foreach(DataRow row in userinfo.Rows)
    {
        string group = row.Field<String>("GroupNumber");
        string[] vals = group.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        foreach(ListItem item in ListBox1.Items)
        {
            item.Selected = vals.Contains(item.Value);
        }
    }
