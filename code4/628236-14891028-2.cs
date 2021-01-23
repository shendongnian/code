    var addrs = x.Descendants().Elements("address")
        			   .Select(y => {
    									ListViewItem item1 = new ListViewItem(y.Attribute("addr").Value);
    									item1.SubItems.Add(y.Attribute("addrtype").Value);
    									return item1;
    								});
    								
    listView.Items.AddRange(addrs);
