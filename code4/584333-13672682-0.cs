    private void ProcessBatch()
    {
         Connection.Open();
         try
         {
            String sql = "...";
            ...
            OleDbDataReader reader = cmd.ExecuteReader();
            ...            
         }
         finally
         {
            Connection.Close();
         }     
     }
