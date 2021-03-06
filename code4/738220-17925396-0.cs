    using (OracleCommand cmd = new OracleCommand())
        {
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
    
            cmd.CommandText = "insert into daily_cdr_logs " +
                    "(message) " +
                    "values " +
                    "(:message)";
    
             OracleParameter pMsg = new OracleParameter();
                pMsg.DbType = DbType.Varchar;
                pMsg.Value = msg;
                pMsg.ParameterName = "message";
    
             cmd.Parameters.Add(pMsg);
    
            //OracleDbType.Int32, postpaid_duration, ParameterDirection.Input);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
