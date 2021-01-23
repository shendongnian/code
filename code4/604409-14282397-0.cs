    // This function returns a row that contains the supplied search criteria
    public Row FindRowFromAutoCompleteBox(RowCollection rootRows, string searchCriteria)
    {
    	foreach (Row row in rootRows)
    	{
    		if (row.Data is LevelOneDataType)
    		{
    			if ((row.Data as LevelOneDataType).LevelOneProperty == searchCriteria)
    				return row;
    		}
    		if (row.Data is LevelTwoDataType)
    		{
    			if ((row.Data as LevelTwoDataType).LevelTwoProperty == searchCriteria)
    				return row;
    		}
    		if (row.Data is LevelThreeDataType)
    		{
    			if ((row.Data as LevelThreeDataType).LevelThreeProperty == searchCriteria)
    				return row;
    		}
    		// Search child rows.
    		if (row.ChildBands.Count != 0)
    		{
    			Row result = FindRowFromAutoCompleteBox(row.ChildBands[0].Rows, searchCriteria);
    			if (result != null)
    				return result;
    		}
    	}
    
    	return null;
    }
    
    // Walks up the hierarchy starting at the supplied row and expands parent rows as it goes.
    public void ExpandHierarchy(Row row)
    {
    	Row parentRow = null;
    
    	// The row is a child of another row.
    	if (row.ParentRow is ChildBand)
    		parentRow = (row.ParentRow as ChildBand).ParentRow;
    
    	while (parentRow != null)
    	{
    		// Expand the row.
    		parentRow.IsExpanded = true;
    
    		if (parentRow.ParentRow is ChildBand)
    			parentRow = (parentRow.ParentRow as ChildBand).ParentRow;
    		else
    			parentRow = null;
    	}
    }
