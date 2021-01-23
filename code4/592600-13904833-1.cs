    ListBox lb = new ListBox();
    lb.Items.Add("12341','2341");
    lb.Items.Add("123415','112341");
    lb.Items.Add("543225','11234134");
    for (int i = 0; i < lb.Items.Count; i++) {
        string item = lb.Items[i] as string;
        item = item.Substring(item.LastIndexOf("','"));
        lb.Items[i] = item;
    }
