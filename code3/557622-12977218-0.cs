    private ListViewItem FindListViewItem(DragEventArgs e)
    {
    	var visualHitTest = VisualTreeHelper.HitTest(_listView, e.GetPosition(_listView)).VisualHit;
    
    	ListViewItem listViewItem = null;
    
    	while (visualHitTest != null)
    	{
    		if (visualHitTest is ListViewItem)
    		{
    			listViewItem = visualHitTest as ListViewItem;
    
    			break;
    		}
    		else if (visualHitTest == _listView)
    		{
    			Console.WriteLine("Found ListView instance");
    			return null;
    		}
    
    		visualHitTest = VisualTreeHelper.GetParent(visualHitTest);
    	}
    
    	return listViewItem;
    }
