    var e = new Dictionary<string, List<string>>();
    
    Sql sql = new Sql("select col1 = 'asd', col2 = 'qwe'");
    var d = mDataAccess.Query<dynamic>(sql);
    
    if (d != null && d.Count() > 0)
    {
    	List<string> cols = new List<string>();
    	foreach (var t in d.First())
    	{
    		cols.Add(t.Key);
    	}
    
    	foreach (var key in cols)
    	{
    		List<string> values = new List<string>();
    		foreach (var row in d)
    		{
    			foreach (var t in row)
    			{
    				if (t.Key == key) values.Add(t.Value.ToString());
    			}
    		}
    		e.Add(key, values);
    	}
    }
    
    return e;
