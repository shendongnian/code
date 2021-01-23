        //run 100 insert statements at a time
        if (counter % 100 == 0)
        {
            postgresSQLDBConnection.PostgreSQLExecutePureSqlNonQuery(postgresQuery.ToString());
            postgresQuery.Clear();
        } 
    }
    if (counter % 100 != 0)
    {
        postgresSQLDBConnection.PostgreSQLExecutePureSqlNonQuery(postgresQuery.ToString());
    } 
