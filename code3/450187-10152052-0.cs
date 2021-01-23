    using (OracleConnection cnn = new OracleConnection(connString)) 
    using (OracleCommand cmd = new OracleCommand("UPDATE TABLE1 SET BIRHDATE=:NewDate WHERE ID=:ID", cnn)) 
    { 
            cmd.Parameters.AddWithValue(":NewDate", YourDateTimeValue);
            cmd.Parameters.AddWithValue(":ID", 111);
            cnn.Open(); 
            cmd.ExecuteNonQuery(); 
    }
