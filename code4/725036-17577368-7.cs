    SqlDatabase db = DatabaseFactory.CreateDatabase("myconnstr") as SqlDatabase;
    
    using ( DbCommand dbCommand = db.GetStoredProcCommand("dbo.ParticipantUpdate") ) {
    	db.AddInParameter(dbCommand, "Participants", SqlDbType.Structured, participantList);
    
    	db.ExecuteNonQuery(dbCommand);
    
    } // using dbCommand
