    private DBEntities db;
    
    // then in your function attempt to initialise
    try{
    
    db = new DBEntities("database");
    
    db.Connection.Open();
    
    }
    catch(Exception ex){
    
    if(db.Connection != ConnectionState.Closed){
    
    db.Connection.Close();
    db.Dispose();
    //go to error page
    }
    
    }
