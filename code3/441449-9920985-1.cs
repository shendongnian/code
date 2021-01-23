    if (oleDataBaseConnection.HasRows())
    {
        int counter = 0;
    
        Spinner spinner = new Spinner();
    
        StringBuilder postgresQuery = new StringBuilder();
    
        Dictionary<string, string> postgreSQLQueries = TypeConversion.GetQueryDictionary("POSTGRESQL");
    
        while (oleDataBaseConnection.NextRecord())
        {
            string postgreSQLInsertQuery;
    
            postgreSQLQueries.TryGetValue("INSERT", out postgreSQLInsertQuery);
    
            postgreSQLInsertQuery = postgreSQLInsertQuery.Replace("{0}", tableName);
                                        spinner.Turn();
    
            postgresQuery.Append(postgreSQLInsertQuery);
    
            postgresQuery.Append("(");
    
            int columnCounter = 0;
    
            //add a column parameter to query for each of our columns
            foreach (KeyValuePair<string, string> t in destinationColumnData)
            {
                 postgresQuery.Append(t.Key + ",");
                 columnCounter++;
            }
    
            postgresQuery = postgresQuery.Remove(postgresQuery.Length - 1, 1);
            postgresQuery.Append(") ");
    
            postgresQuery.Append("VALUES (");
    
            //Loop through values for column names/types
            for (int i = 0; i < columnCounter; i++)
            {
                if (String.IsNullOrEmpty(oleDataBaseConnection.GetFieldById(i)))
                {
                     postgresQuery.Append("NULL, ");
                }
                else
                {
                     switch (foobar[i].ToUpper())
                     {
                         case "TEXT":
                             postgresQuery.Append("$$" + oleDataBaseConnection.GetFieldById(i) + "$$, ");
                             break;
                         case "GEOMETRY":
                             postgresQuery.Append("ST_GeomFromText('" + oleDataBaseConnection.GetFieldById(i) + "'), ");
                             break;
                         default:
                             postgresQuery.Append(oleDataBaseConnection.GetFieldById(i) + ", ");
                             break;
                     }
                 }
             }
    
             postgresQuery = postgresQuery.Remove(postgresQuery.Length - 2, 2);
             postgresQuery.Append(") ");
    
             counter++;
    
             //run 100 insert statements at a time
             if (counter % 100 == 0)
             {
                 postgresSQLDBConnection.PostgreSQLExecutePureSqlNonQuery(postgresQuery.ToString());
    
                 postgresQuery.Clear();
             } 
         }
         // this is outside the main loop (but inside the HasRows check)
         // Could check if stringbuilder has just been cleared.
         if (postgresQuery.Length > 0)
         {
            postgresSQLDBConnection.PostgreSQLExecutePureSqlNonQuery(postgresQuery.ToString());
            postgresQuery.Clear();
         }
     }
