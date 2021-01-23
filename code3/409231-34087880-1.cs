    List<string> GetColumnNames(IDataReader reader)
    {
    	List<string> columnNames = new List<string>();
    	for (int i = 0; i < reader.FieldCount; i++)
    	{
    		 columnNames.Add(reader.GetName(i));
    	}
    
    	return columnNames;
    }
