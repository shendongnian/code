    public static DataTable TramnsformRelationshipData(DataTable relationshipData, Dictionary<string, DataTable> mapping) 
    	{ 
    		Dictionary<string,Dictionary<string,DataRow>> newMappings = new Dictionary<string,Dictionary<string,DataRow>>();
    		foreach (var kvp in mapping)
    		{
    			newMappings.Add(kvp.Key,kvp.Value.Rows.Cast<DataRow>().ToDictionary(dr=>dr["ID"] as string));
    		}
    		
    		DataTable transformedDataTable = null; 
    		if (relationshipData == null || mapping == null ) 
    		   return null; 
     
    		transformedDataTable = relationshipData.Copy(); 
     
    		foreach (DataColumn item in relationshipData.Columns) 
    		{ 
    			if (newMapping.ContainsKey(item.ColumnName)) 
    			{ 
    				var instanceData = newMapping[item.ColumnName]; 
    				if (instanceData == null) 
    					return null; 
     				
    				foreach (DataRow row in transformedDataTable.Rows) 
    				{ 
    				//	var filteredRows = instanceData.Select("ID = '" + row[item.ColumnName] + "'"); 
    				//	if (filteredRows.Any()) 
    					row[item.ColumnName] = instanceData[row[item.ColumnName]][1];						
    				} 
    			} 
    		} 
     
    		return transformedDataTable; 
    	} 
