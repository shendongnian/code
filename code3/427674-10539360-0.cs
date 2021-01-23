    void MakeSureListViewGroupHeaderShows(ListView lv)
    {
    	foreach (ListViewGroup lvg in lv.Groups)
    	{
    		if (lvg.Items.Count == 0)
    		{
    			// add empty list view item
    			ListViewItem lvi = new ListViewItem(string.Empty);
    			lvi.Group = lvg;
    			lv.Items.Add(lvi);
    		}
    		else
    		{
    			// remove our dummy list view item
    			foreach (ListViewItem lvi in lvg.Items)
    			{
    				if (lvi.Text == string.Empty)
    				{
    					lvi.Remove();
    				}
    			}
    		}
    	}
    }
