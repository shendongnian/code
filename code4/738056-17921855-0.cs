    String msg = "something here";
    using (OracleConnection con = new OracleConnection(...insert connection params here...))
    {
      con.Open();
      OracleCommand cmd = con.CreateCommand();
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = @"
            insert into daily_cdr_logs
            (message) 
            values 
            (:message)";
      cmd.Parameters.AddWithValue("message", msg);
      cmd.ExecuteNonQuery();
    }
