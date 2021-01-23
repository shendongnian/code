    public void Populate()
    {
    	Datatable data = GetData();
    	
    	foreach(DataRow r in data.Rows)
    	{
    		/// Populate chart using data
    	}
    }
    
    public DataTable GetData()
    {
    	try
    	{
    	OleDbConnection myConnection = new OleDbConnection;();
        myConnection.ConnectionString = myConnectionString;
        myConnection.Open();
    	
    	OleDbCommand myCommand = myConnection.CreateCommand();
    	
    	//Set commandtype and text here.
    	myCommand.CommandType = SOMETYPE;
    	myCommand.CommandText = "SOMETEXT";
    	
    	OleDbDataReader reader = myCommand.ExecuteReader();
    	
    	DataTable t = new DataTable();
    	t.Load(reader);
    	
    	return t;
    	}
    	catch (Exception e)
    	{
    		throw e;
    	}
    	finally
    	{
    		myConnection.Close();
    	}
    }
