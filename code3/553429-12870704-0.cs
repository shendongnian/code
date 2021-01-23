    using(dbCommand = new SqlCommand())
    {
      dbCommand.CommandText="sp_EVENT_UPATE";
      dbCommand.Connection=dbConnection;
      dbCommand.CommandType=CommandType.StoredProcedure;
      dbCommand.Parameters.AddWithValue("@EventID",currentEvent.EventID);
      ....
      dbConnection.Open();
      dbCommand.ExecuteNonQuery();
      dbConnection.Close();
     }
