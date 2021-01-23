    public void AddGroup(ListViewGroup lg)
    {
        if (lg.Items.Count > 0)
            lv.Groups.Add(lg);
        else
        {
            var item = lv.Items.Add(lg.Header);
            item.Tag = lg;
        }
    }
    public void AddItem(ListViewItem li, string groupKey) // Could also take ListViewGroup here...
    {
        if (lv.Groups[groupKey] == null && lv.Items.ContainsKey(groupKey))
        {
            lv.Groups.Add((ListViewGroup)lv.Items[groupKey].Tag);
            lv.Items.RemoveByKey(groupKey);
        }
        lv.Items.Add(li);
        li.Group = lv.Groups[groupKey];
    }
