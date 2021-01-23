    using (var connection = new SqlConnection(connectionString))
    using (var comm = new SqlCommand("Select TOP 1 OrderID From [GIS].[SecondaryTraffic].[PotentialBackHauls] ORDER BY InsertDate DESC", connection))
    {
        connection.Open();
    
        object result = comm.ExecuteScalar(); // This is the key bit you were missing.
       
        if (result != null)
        {
            // You can cast result to something useful
            int orderId = (int)result;
        }
    }
