    OleDbCommand command    = new OleDbCommand(null, rConn);
    
    // Create and prepare an SQL statement.
    command.CommandText = "insert into Region (RegionID, RegionDescription) values (@id, @desc)" ;
    command.Parameters.Add ( "@id", id) ;
    command.Parameters.Add ( "@desc", desc) ;
    command.Prepare() ;  // Calling Prepare after having set the Commandtext and parameters.
    command.ExecuteNonQuery();
    
    // Change parameter values and call ExecuteNonQuery.
    command.Parameters[0].Value = 21;
    command.Parameters[1].Value = "mySecondRegion";
    command.ExecuteNonQuery();
