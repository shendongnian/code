     using (OracleConnection conn = new OracleConnection(connString))
     {
         // Open connection and create command.
         conn.Open();
         using (OracleCommand cmd = new OracleCommand())
         {
             cmd.Connection = conn;
             cmd.CommandType = CommandType.Text;
             cmd.Parameters.Add("outValue", OracleType.Int32).Direction = ParameterDirection.Output;
             cmd.CommandText = "insert into table (id, value) values (seq.nextval, 'value') returning id into :outValue";
             cmd.ExecuteNonQuery();
         }
     }
