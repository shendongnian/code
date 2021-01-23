    using (var db = new DbConnect("connection string"))
    {
        db.SetSqlCommand("UpdateTeamStats");
        db.AddParameter("teamId", 21);
        db.AddParameter("points", 2);
    
        db.ExecuteNonQuery().Wait(); //OR if youre async await db.ExecuteNonQuery();
    
        db.ClearParameters();
        db.SetSqlCommand("some other proc");
    
        //rest of executions
    }
