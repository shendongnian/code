    foreach(string lineItem in yaArray)
    {
      string[] listViewRow = lineItem.Split(new string[] { ";" }, StringSplitOptions.None); //Now we split on the semi colon to give us each item
      ListViewItem newItem = new ListViewItem(listViewRow[0]);
      newItem.SubItems.Add(listViewRow[1];
      listView1.Items.Add(newItem);
    }
