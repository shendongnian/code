    public static DataTable GetDataTable(string tableName)
    	{
            	lock (lockMe)
        
        		{
                        if (!dictionary.Keys.Contains(tableName))
                        {
                            ReadTableIntoMemory(tableName);
                        }
                        
                       return dictionary[tableName];
            	}
                       
    	}
