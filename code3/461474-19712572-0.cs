    try
    {
    	bulkCopy.WriteToServer(importTable);
    	sqlTran.Commit();
    }    
    catch (SqlException ex)
    {
    	if (ex.Message.Contains("Received an invalid column length from the bcp client for colid"))
    	{
    		string pattern = @"\d+";
    		Match match = Regex.Match(ex.Message.ToString(), pattern);
    		var index = Convert.ToInt32(match.Value) -1;
    					  
    		FieldInfo fi = typeof(SqlBulkCopy).GetField("_sortedColumnMappings", BindingFlags.NonPublic | BindingFlags.Instance);
    		var sortedColumns = fi.GetValue(bulkCopy);
    		var items = (Object[])sortedColumns.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sortedColumns);
    						
    		FieldInfo itemdata = items[index].GetType().GetField("_metadata", BindingFlags.NonPublic | BindingFlags.Instance);
    		var metadata = itemdata.GetValue(items[index]);
    
    		var column = metadata.GetType().GetField("column", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
    		var length = metadata.GetType().GetField("length", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
    		throw new DataFormatException(String.Format("Column: {0} contains data with a length greater than: {1}", column, length));
    	}
}
