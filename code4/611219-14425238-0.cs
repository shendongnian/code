    // Determine if clicked column is already the column that is being sorted.
    if ( e.Column == lvwColumnSorter.SortColumn )
    {
    	// Reverse the current sort direction for this column.
    	if (lvwColumnSorter.Order == SortOrder.Ascending)
    	{
    		lvwColumnSorter.Order = SortOrder.Descending;
    	}
    	else
    	{
    		lvwColumnSorter.Order = SortOrder.Ascending;
    	}
    }
    else
    {
    	// Set the column number that is to be sorted; default to ascending.
    	lvwColumnSorter.SortColumn = e.Column;
    	lvwColumnSorter.Order = SortOrder.Ascending;
    }
    
    // Perform the sort with these new sort options.
    this.listView1.Sort();
			
