    string separator = ";";
    string fieldDelimiter = "";
    bool useHeaders = true;
    string connectionString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
    
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
    	 using (SqlCommand cmd = conn.CreateCommand())
    	 {
    		  conn.Open();
    		  string query = @"SELECT whatever";
    
    		  cmd.CommandText = query;
    
    		  using (SqlDataReader reader = cmd.ExecuteReader())
    		  {
    				if (!reader.Read())
    				{
    					 return;
    				}
    
    				List<string> columnNames = GetColumnNames(reader);
    
    				// Write headers if required
    				if (useHeaders)
    				{
    					 first = true;
    					 foreach (string columnName in columnNames)
    					 {
    						  response.Write(first ? string.Empty : separator);
    						  line = string.Format("{0}{1}{2}", fieldDelimiter, columnName, fieldDelimiter);
    						  response.Write(line);
    						  first = false;
    					 }
    
    					 response.Write("\n");
    				}
    
    				// Write all records
    				do
    				{
    					 first = true;
    					 foreach (string columnName in columnNames)
    					 {
    						  response.Write(first ? string.Empty : separator);
    						  string value = reader[columnName] == null ? string.Empty : reader[columnName].ToString();
    						  line = string.Format("{0}{1}{2}", fieldDelimiter, value, fieldDelimiter);
    						  response.Write(line);
    						  first = false;
    					 }
    
    					 response.Write("\n");
    				}
    				while (reader.Read());
    		  }
    	 }
    }
