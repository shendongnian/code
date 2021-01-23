    ListViewItem item1 = new ListViewItem( "Item 1"); 
    item1.SubItems.Add( "Color" ); 
    item1.SubItems[1].ForeColor = System.Drawing.Color.Blue;
    item1.UseItemStyleForSubItems = false; 
    listView1.Items.Add( item1 ); 
