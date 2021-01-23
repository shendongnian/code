    private void TreeViewDoubleClick(object sender, EventArgs e)
    {
    	var localPosition = treeView.PointToClient(Cursor.Position);
    	var hitTestInfo = treeView.HitTest(localPosition);
    	if (hitTestInfo.Location == TreeViewHitTestLocations.StateImage) 
    		return;
    
    	// ... Do whatever other processing you want
    }
