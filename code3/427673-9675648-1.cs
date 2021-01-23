    public static void AddGroup(this ListView lv, ListViewGroup lg)
    {
        if (lg.Items.Count > 0 || lv.Items.Cast<ListViewItem>().Any(tg => tg.Group == lg))
            lv.Groups.Add(lg);
        else
        {
            var item = lv.Items.Add(lg.Header);
            item.Tag = lg;
        }
    }
    public static void AddItem(this ListView lv, ListViewItem li, string groupKey) // Could also take ListViewGroup here...
    {
        if (lv.Groups[groupKey] == null && lv.Items.ContainsKey(groupKey))
        {
            lv.Groups.Add((ListViewGroup)lv.Items[groupKey].Tag);
            lv.Items.RemoveByKey(groupKey);
        }
        lv.Items.Add(li);
        li.Group = lv.Groups[groupKey];
    }
    public static void AddItem(this ListView lv, ListViewItem li, ListViewGroup lg)
    {
        lv.AddItem(li, lg.Header);
    }
