    OleDbCommand cmd1 = new OleDbCommand("SELECT * from Number, Id", cn);
    OleDbDataReader reader = cmd1.ExecuteReader();
    
    while( reader.Read() )
    {
       var Number= reader[0];
       var Id = reader[1];
    					
       if(Id == DBNull.Value || WoNumber == DBNull.Value)
       {
    	   break;
       }
    
       results.Add(Convert.ToInt32(Id), Convert.ToInt32(Number));
    }
