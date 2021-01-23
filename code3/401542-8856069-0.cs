    bool roominspiration = false;
    query = "SELECT room_inspiration FROM Room WHERE room_id = @room_id); SELECT SCOPE_IDENTITY();";
    using (sqlConnection1)
    {
      using (SqlCommand cmd = new SqlCommand(query, sqlConnection1))
      {
        cmd.Parameters.Add("@room_id", System.Data.SqlDbType.Int);
        cmd.Parameters["@room_id"].Value = roomid;
        sqlConnection1.Open();
        roominspiration = ((bool?)cmd.ExecuteScalar()).GetValueOrDefault();
      }
    }
