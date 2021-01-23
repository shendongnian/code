    public String GetPrimaryKey(String strTable)
    {
    	try
    	{
    		Boolean bIsPrimary = false;
    		String strIndexName = null;
    		String strColumnName = null;
    		String[] strRestricted = new String[4] { null, null, strTable, null      };
    		DataTable oSchemaIndexes = null;
    		DataTable oSchemaIndexColumns = null;
    
    
    		// Make sure that there is a connection.
    		if (ConnectionState.Open != this.m_oConnection.State)
    			this.m_oConnection.Open();
    
    		// DATABASE: Get the schemas needed.
    		oSchemaIndexes = this.m_oConnection.GetSchema("Indexes", strRestricted);
    		oSchemaIndexColumns = this.m_oConnection.GetSchema("IndexColumns", strRestricted);
    
    		// Get the index name for the primary key.
    		foreach (DataRow oRow in oSchemaIndexes.Rows)
    		{
    			// If we have a primary key, then we found what we want.
    			strIndexName = oRow["INDEX_NAME"].ToString();
    			bIsPrimary = (Boolean)oRow["PRIMARY"];
    			if (true == bIsPrimary)
    				break;
    		}
    
    		// If no primary index, bail.
    		if (false == bIsPrimary)
    			return null;
    
    		// Get the corresponding column name.
    		foreach (DataRow oRow in oSchemaIndexColumns.Rows)
    		{
    			// Get the column name.
    			if (strIndexName == (String)oRow["INDEX_NAME"])
    			{
    				strColumnName = (String)oRow["COLUMN_NAME"];
    				break;
    			}
    		}
    
    		return strColumnName;
    	}
    
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
    
    	return null;
    }
