    var factory = MySqlClientFactory.Instance;
    string connectionString = "Server=localhost;Port=3306;Database=test;User ID=user;Password=user";
    // DDL cannot be performed in transaction as will commit
    using (var connection = factory.CreateConnection())
    {
        connection.ConnectionString = connectionString;
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = "CREATE TABLE TestTable (ID INT) ENGINE = InnoDB DEFAULT CHARSET=utf8;";
        command.ExecuteNonQuery(); // will always commit here
    }
    // DML can be performed in transaction
    using (var transaction = new System.Transactions.TransactionScope())
    using (var connection = factory.CreateConnection())
    {
        connection.ConnectionString = connectionString;
        connection.Open();   
        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO TestTable (ID) VALUES (123);";
        command.ExecuteNonQuery();
        // should rollback here
        //transaction.Complete();
    }
