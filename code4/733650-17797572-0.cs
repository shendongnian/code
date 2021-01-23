    foreach(var p in listProf)
    {
        var item = new ListViewItem{Text = p.Name, Tag = p};
        ListView1.Items.Add(item);
        ListView2.Items.Add((ListViewItem)item.Clone());
    }
