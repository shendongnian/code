    private void listView_MouseClick(object sender, MouseEventArgs e)
    {
    	// Hittestinfo of the clicked ListView location
    	ListViewHitTestInfo listViewHitTestInfo = listView.HitTest(e.X, e.Y);
    
    	// Index of the clicked ListView column
    	int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
    	
    	...
    }
