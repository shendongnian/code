    private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
    {
    	csvData = new DataTable(defaultTableName);
    	try
    	{
    		using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
    		{
    			csvReader.SetDelimiters(new string[]
    			{
    				tableDelim 
    			});
    			csvReader.HasFieldsEnclosedInQuotes = true;
    			string[] colFields = csvReader.ReadFields();
    			foreach (string column in colFields)
    			{
    				DataColumn datecolumn = new DataColumn(column);
    				datecolumn.AllowDBNull = true;
    				csvData.Columns.Add(datecolumn);
    			}
    
    			while (!csvReader.EndOfData)
    			{
    				string[] fieldData = csvReader.ReadFields();
    				//Making empty value as null
    				for (int i = 0; i < fieldData.Length; i++)
    				{
    					if (fieldData[i] == string.Empty)
    					{
    						fieldData[i] = string.Empty; //fieldData[i] = null
    					}
    					//Skip rows that have any csv header information or blank rows in them
    					if (fieldData[0].Contains("Disclaimer") || string.IsNullOrEmpty(fieldData[0]))
    					{
    						continue;
    					}
    				}
    				csvData.Rows.Add(fieldData);
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    	}
    	return csvData;
    }
