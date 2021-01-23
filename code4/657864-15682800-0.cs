        public static void CompareRows(DataTable table1, DataTable table2)
        {
    	foreach (DataRow row1 in table1.Rows)
    	{
    	    foreach (DataRow row2 in table2.Rows)
    	    {
    		var array1 = row1.ItemArray;
    		var array2 = row2.ItemArray;
    
    		if (array1.SequenceEqual(array2))
    		{
    		    Console.WriteLine("Equal: {0} {1}", row1["ColumnName"], row2["ColumnName"]);
    		}
    		else
    		{
    		    Console.WriteLine("Not equal: {0} {1}", row1["ColumnName"], row2["ColumnName"]);
    		}
    	    }
    	}
        }
