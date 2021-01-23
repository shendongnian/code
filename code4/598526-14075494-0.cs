    // Connect to the database.
    SqlConnection connection = new SqlConnection(Database.ConnectionString);
    connection.Open();
    
    // Start a transaction.
    SqlCommand command = new SqlCommand();
    command.Connection = connection;
    command.Transaction = connection.BeginTransaction(System.Data.IsolationLevel.Serializable, "ryan");
    
    // Delete any previously associated targets.
    command.CommandType = System.Data.CommandType.StoredProcedure;
    command.CommandText = "FirstSP";
    command.Parameters.AddWithValue("@Id", this.Id);
    command.ExecuteNonQuery();
    
    // Add the specified targets to the product.
    command.CommandText = "SecondSP";
    command.Parameters.Add("@Id", SqlDbType.Int);
    foreach (int Id in Ids)
    {
        command.Parameters["@Id"].Value = Id;
        command.ExecuteNonQuery();
    }
    
    // Commit the transaction.
    command.Transaction.Commit();
    
    // Houseclean.
    connection.Close();
