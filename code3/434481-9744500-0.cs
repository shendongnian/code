    private void UpdateListView()
    {
       mListView.Items.Clear();
       foreach (Item item in mItems)
       {
          ListViewItem listViewItem = 
             new ListViewItem(item.Value1.ToString()) { Tag = item; }
          listViewItem.SubItems.Add(item.Value2.ToString());
          listViewItem.SubItems.Add(item.Value3.ToString());
          mListView.Items.Add(listViewItem);
       }
    }
