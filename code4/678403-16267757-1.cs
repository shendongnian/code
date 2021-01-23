    public DataTable fillMissingHours(DataTable currentDataTable)
    {
    	// iterates through the current DataTable to find missing data and fill it in with
    	// the correct DateTime and NULL DataValue
    	DataRow row;
    	DateTime curRowDt, nextRowDt;
    	object curObj, nextObj; // Used only for conversions
    
    	for (int i = 0; i < currentDataTable.Rows.Count - 1; ++i)
    	{
    		curObj = currentDataTable.Rows[i][0];
    		nextObj = currentDataTable.Rows[i + 1][0];
    		curRowDt = Convert.ToDateTime(curObj);
    		nextRowDt = Convert.ToDateTime(nextObj);
    
    		if (curRowDt.AddHours(1.0) != nextRowDt)
    		{
    			TimeSpan deltaTime = nextRowDt - curRowDt;
    			for (int j = 1; j < deltaTime.TotalHours; ++j)
    			{
    				++i;
    				row = currentDataTable.NewRow();
    				row.ItemArray = new object[] { curRowDt.AddHours(j), null };
    				currentDataTable.Rows.InsertAt(row, i);
    			}
    		}
    	}
    
    	return currentDataTable;
    }
