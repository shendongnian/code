    public class ArchiveTableRow
    {
    	private static readonly IDictionary<string, string> _cachedInsertStatements = new Dictionary<string, string>();
    
    	public void Archive(string tableName, string rowId)
    	{	
    		if (_cachedInsertStatements.ContainsKey(tableName) == false)
    		{
    			BuildInsertStatement(tableName);
    		}
    		
    		var insertQuery = _cachedInsertStatements[tableName];
    		
    		// ...		
    		SqlCommand archiveComm = new SqlCommand(insertQuery, conn);
    		// ...		
    		archiveComm.Parameters.AddWithValue("ArchiveTimeStamp", Date.Time.Now);		
    		// ...		
    	}
    	
    	private void BuildInsertStatement(string tableName)
    	{
    		// Get the columns names:
    		var getColumnNamesQuery = @"
    			SELECT Table_Schema, Column_Name
    			FROM Information_Schema.Columns
    			WHERE Table_Name = '" + tableName + "'
    			Order By Ordinal_Position";
    				
    		// Execute the query
    		SqlCommand archiveComm = new SqlCommand(getColumnNamesQuery, conn);
    				
    		// Loop and build query and add your archive in the end
    		
    		// Add to dictionary	
    	}	
    }
