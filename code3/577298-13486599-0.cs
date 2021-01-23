    public string[] getColumns(bool ColumnNames)
    {
    	try {
    		StreamReader fileReader = new StreamReader(FileName);
    		string line = fileReader.ReadLine;
    		fileReader.Close();
    		string[] Columns = line.Split(",");
    		if (ColumnNames) {
    			return Columns;
    		}
    		int i = 1;
    		int c = 0;
    		string[] columnsNames = new string[Columns.Count];
    		foreach (string column in Columns) {
    			columnsNames(c) = "column" + i;
    			i += 1;
    			c += 1;
    		}
    		return columnsNames;
    	} catch (Exception ex) {
    		//log to file    
    	}
    	return null;
    }
