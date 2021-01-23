    OleDbConnection aConnection = new 
        OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName);
    
    OleDbCommand aCommand = new OleDbCommand("Table1", aConnection);
    aCommand.CommandType = CommandType.TableDirect;
    aConnection.Open();
    OleDbDataReader aReader = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
    DataTable schemaTable = aReader.GetSchemaTable();
    aReader.Close();
    aConnection.Close();
    	
    bool optionalInfoColumnExists = schemaTable.Columns.Contains("Optional Info");	
