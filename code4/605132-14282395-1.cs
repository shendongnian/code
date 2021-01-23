        table.Columns.Add("UID", typeof(int));
    	table.Columns.Add("name", typeof(string));
       using (var varConnection = Locale.sqlConnectOneTimeMySql(Locale.sqlDataConnectionDetailsMySQL))
        using (var sqlQuery = new MySqlCommand(preparedCommand, varConnection)) {
            using (var sqlQueryResult = sqlQuery.ExecuteReader())                 
                    while (sqlQueryResult.Read()) {
    //above is basic sql stuff i expect you know
    //Here's where you ge thte data
                        int uid = sqlQueryResult["UID"] is int ? (int)sqlQueryResult["UID"] : 0;
                        string name = sqlQueryResult["name"].ToString();
    
    // here is where you're outputting to your table
                        table.Rows.Add(uid,name); 
                    }
             }
        }
