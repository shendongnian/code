    public DataTable ReturnData(bool ColumnNames)
    {
    	try {
    		DataTable dt = new DataTable();
    		foreach ( columnName in getColumns(ColumnNames)) {
    			dt.Columns.Add(columnName);
    		}
    		StreamReader fileReader = new StreamReader(FileName);
    		if (ColumnNames) {
    			fileReader.ReadLine();
    		}
    		string line = fileReader.ReadLine;
    		while ((line != null)) {
    			line = line.Replace(Strings.Chr(34), "");
    			dt.Rows.Add(line.Split(","));
    			line = fileReader.ReadLine;
    		}
    		fileReader.Close();
    		return dt;
    	} catch (Exception ex) {
    		//log to file
    	}
    	return null;
    }
