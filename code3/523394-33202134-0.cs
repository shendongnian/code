        using (var txn = new TransactionScope(
                                TransactionScopeOption.Required,
                                new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted, Timeout = new TimeSpan(1,0,0) })) // 1 hour or wathever, will not affect anything
                        {
        
                            using (SqlConnection connection = new SqlConnection(ConnectionString))
                            {
                                int ct = connection.ConnectionTimeout // (read Only, this is the effective default timeout is 15 seconds)
                                connection.Open();
        
                                SqlCommand select = new SqlCommand(sql.query, connection); // bind to server
                                select.CommandTimeout = 0; // <-- here does apply infinite timeout
    SqlDataReader reader = select.ExecuteReader(); // never stop
