    public IEnumerable<t> TypeSomething
    {
    	get
    	{
    		if (db != null)
    		{
    			t col = db.Select<t>();
    			if (col.Count > 0) return col;
    		}
    		return GetDB<t>();
    	}
    }
