    string connStr = "Data Source = DBName.sdf; Password = DBPassword";  
    
    if (!File.Exists("DBName.sdf")){
    
    try  {     
    SqlCeEngine engine = new SqlCeEngine(connStr);  
    engine.CreateDatabase();  
    
    SqlCeConnection conn = new SqlCeConnection(connStr);     
    conn.Open();      
    
    SqlCeCommand cmd = conn.CreateCommand();     
    cmd.CommandText = "CREATE TABLE TableName(Col1 int, Col2 varchar(20))";     
    cmd.ExecuteNonQuery(); 
    
    } 
    catch (SQLException ex){
        // Log the exception
    } 
    finally  {     
    conn.Close(); 
    }
    } 
