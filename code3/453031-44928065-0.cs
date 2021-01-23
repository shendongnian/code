    using (var conn = new SqlConnection("connection string"))
    {
        using (var cmd = new SqlCommand())
        {
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
    
            //ready to query 
            conn.Open();
    
            cmd.CommandText = "UpdateTeamStats";
            var teamIdParam = new SqlParameter("teamId", 21);
            var pointsParam = new SqlParameter("points", 2);
    
            cmd.Parameters.Add(teamIdParam);
            cmd.Parameters.Add(pointsParam);
    
            cmd.ExecuteNonQuery(); //OR if you're async cmd.ExecuteNonQueryAsync();
    
            //the rest of your executions
            conn.Close();
        }
    }
