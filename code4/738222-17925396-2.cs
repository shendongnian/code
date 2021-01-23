    using (OracleCommand cmd = new OracleCommand())
        {
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
    
            cmd.CommandText = "insert into daily_cdr_logs " +
                    "(message) " +
                    "values " +
                    "(:message)";
    
             OracleParameter pMsg = new OracleParameter("message",OracleDbType.Varchar2);
                pMsg.Value = msg;
    
             cmd.Parameters.Add(pMsg);
    
            //OracleDbType.Int32, postpaid_duration, ParameterDirection.Input);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
