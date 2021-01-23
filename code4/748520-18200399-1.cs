    private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
       {
           ListViewItem lvi = new ListViewItem(); 	// create a listviewitem object
           lvi.Text = nt.MakeText(e.ItemIndex); 		// assign the text to the item
           ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem(); // subitem
           NumberFormatInfo nfi = new CultureInfo("de-DE").NumberFormat;
           nfi.NumberDecimalDigits = 0;
           lvsi.Text = e.ItemIndex.ToString("n", nfi); 	// the subitem text
           lvi.SubItems.Add(lvsi); 			// assign subitem to item
    
           e.Item = lvi; 		// assign item to event argument's item-property
       } 
