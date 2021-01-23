    using (var SQLCmd = new SqlCeCommand(Query)) 
    { 
         SQLCmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = DataID; 
         SQLCmd.Parameters.Add("@Height", SqlDbType.Int).Value = alt; 
         con.CeExecuteNonQuery(SQLCmd); 
    } 
