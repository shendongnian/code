        private void InsertOrUpdateItem(ListView listView, string[] saLvwItem)
        {
            if (saLvwItem == null || saLvwItem.Length < 4)
            {
                return;
            }
    
            bool bFound = false;
            foreach (ListViewItem lvi in listView.Items)
            {
                if (lvi.SubItems[2].Text == saLvwItem[2])
                {
                    // item already in list
                    // increase the ItemNumber
                    lvi.SubItems[1].Text = (Convert.ToInt32(lvi.SubItems[1].Text) + Convert.ToInt32(saLvwItem[1])).ToString();
                    bFound = true;
                    break;
                }                
            }
    
            if (!bFound)
            {
                // item not found
                // create new item
                ListViewItem newItem = new ListViewItem(saLvwItem);
                listView.Items.Add(newItem);
            }
    
        }
