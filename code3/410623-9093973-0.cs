    sqlConnection = new SqlConnection(<ConnectionString>);
    sqlCommand = new _SQLCli.SqlCommand("Select youthclubname from youthclublist WHERE ([YouthClubID] = @YouthClubID)",sqlConnection);
                sqlCommand.Parameters
                             .Add(new _SQLCli.SqlParameter( "@YouthClubID", <neededValue>);)
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                
