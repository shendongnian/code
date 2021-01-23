    using(OracleConnection cnn = new OracleConnection(connString)) 
    using (OracleCommand cmd = new OracleCommand("SELECT * FROM TABLE1 WHERE 1=0", cnn))  
    {
         OracleAdapter adp = new OracleDataAdapter();
         adp.SelectCommand = cmd;
         // The OracleDataAdapter will build the required string for the update command
         // and will act on the rows inside the datatable who have the  
         // RowState = RowState.Changed Or Inserted Or Deleted
         adp.Update(yourDataTable);
    }
