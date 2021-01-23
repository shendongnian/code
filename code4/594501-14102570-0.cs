    private void CreateAndExportLegacyFile(string exportFilePath)
    {
    	var connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;";
    	connectionString += "Data Source=" + exportFilePath + ";Jet OLEDB:Engine Type=5";
    
    	var catalog = new Catalog();
    	catalog.Create(connectionString);
    
    	var table = new Table { Name = "Main" };
    
    	#region Column mapping
    	table.Columns.Append("ID", DataTypeEnum.adVarWChar, 50);
    	// Snipped rest of them
    	#endregion
    
    	foreach (Column column in table.Columns)
    	{
    		if (column.Name != "ID")
    		{
    			column.Attributes = ColumnAttributesEnum.adColNullable;
    		}
    	}
    
    	catalog.Tables.Append(table);
    
    	Marshal.FinalReleaseComObject(table);
    	Marshal.FinalReleaseComObject(catalog.Tables);
    	Marshal.FinalReleaseComObject(catalog.ActiveConnection);
    	Marshal.FinalReleaseComObject(catalog);
    }
