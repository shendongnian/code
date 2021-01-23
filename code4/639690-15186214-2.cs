    public int CreateEmptyRow<TTable, TRow>() 
    	where TRow : DataRow, new()
    	where TTable : ITable<TRow>, new()
    {
    	var table = new TTable();
    	return table.Insert(new TRow());
    }
