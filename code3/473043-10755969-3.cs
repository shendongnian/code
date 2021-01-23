    // adding data
    listView1.Items.Add(new ListViewItem(new string[] { "John", "10" }));
    listView1.Items.Add(new ListViewItem(new string[] { "Peter", "14" }));
    listView1.Items.Add(new ListViewItem(new string[] { "Markus", "9" }));
    // setting comparer and sorting
    listView1.ListViewItemSorter = new PointsComparer();
    listView1.Sort();
