    public static List<Dictionary<string, object>> ToJsonStructure(this DataTable table)
    {
    	if (table == null) throw new ArgumentNullException("table");
    
    	List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
    	Dictionary<string, object> obj;
    
    	foreach (DataRow r in table.Rows)
    	{
    		obj = new Dictionary<string, object>();
    
    		foreach (DataColumn c in table.Columns)
    		{
    			obj[c.ColumnName] = r[c.ColumnName];
    		}
    
    		data.Add(obj);
    	}
    
    	return data;
    }
