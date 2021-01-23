    using (TransactionScope transactionScope = new TransactionScope()) {
        using (SqlConnection connection = new SqlConnection(connectionString)) {
        connection.Open();
        connection.Close();
        connection.Open(); // escalates to DTC
          }
    }
