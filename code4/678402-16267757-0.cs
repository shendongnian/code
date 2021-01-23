    public DataTable fillMissingHours(DataTable currentDataTable)
    {
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
    			for (int j = 1; j < nextRowDt.Subtract(curRowDt).Hours; ++j)
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
