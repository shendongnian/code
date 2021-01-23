    Database.SetInitializer<OurdatabaseModel>(new OurdatabaseInitializer());
    _instance = new OurdatabaseModel();
    
    try
    {
		// force model creation
    	_instance.OneTable.Any();
    }
    catch (InvalidOperationException)
    {
    	if (_instance == null)
    	{
    		throw;
    	}
    
    	// database exists. Let's back it up.
    	string dbPath = _instance.Database.Connection.Database.Replace("|DataDirectory|", Program.DataDirectory);
    	File.Move(dbPath, dbPath + "." + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".sdf");
    	
		// and now the CreateDatabaseIfNotExists<T> will take care of the rest
		_instance = new OurdatabaseModel();
    }
