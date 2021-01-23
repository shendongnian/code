    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        int insertedIdentity;
        using (SqlCommand command = new SqlCommand("INSERT INTO TableNames(ColumnsList) VALUES(@ValuesList) SELECT @InsertedIdentity = SCOPE_IDENTITY()", connection, transaction))
        {
            command.CommandType = CommandType.Text;
            //Add any parameters required by INSERT here, then add parameter for SCOPE_IDENTITY
            ...
            command.Parameters.Add(new SqlParameter("@InsertedIdentity", SqlDbType.Decimal) { Direction = ParameterDirection.Output });
            command.ExecuteNonQuery();
            insertedIdentity = Convert.ToInt32(command.Parameters["@InsertedIdentity"].Value);
        }
        //Now you can make all the child inserts using insertedIdentity and transaction
        ...
    
        transaction.Commit();
    }
