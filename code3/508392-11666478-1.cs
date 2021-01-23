    DataTable table = GetTable(); // Get the data table.
    	foreach (DataRow row in table.Rows) // Loop over the rows.
    	{
    	    
    	    string getvalue= row[1].ToString();
    		If( getvalue == your condition || getvalue == DBNull.Value)
    			{
    				table.Row.Remove(row[1]);
    			}
    }	}
