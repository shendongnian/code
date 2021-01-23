    private readonly _connectionString = "...";
    public void End(string spSendEventNotificationEmail) {
      using(var conn = new SqlConnection(_connectionString))
      using(var cmd = conn.CreateCommand())
      {
        cmd.CommandText = spSendEventNotificationEmail;
        cmd.Parameters.Add("@packetID", SqlDbType.Int).Value = _packetID;
        cmd.Parameters.Add("@statusID", SqlDbType.Int).Value = _statusID;
        cmd.Parameters.Add("@website", SqlDbType.NVarChar, 100).Value = Tools.NextStep;
        conn.Open();
        cmd.ExecuteNonQuery();
      }
      endCall = true;
    }
