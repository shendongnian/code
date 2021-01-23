    DataTable mysqlfirstTableRowsTobeCopied = GetDataTableFromMySQLTable();
  
    SqlConnection conn = new SqlConnection("Your connection String");
    SqlCommand cmd = new SqlCommand("sp_BatchInsert", conn);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.UpdatedRowSource = UpdateRowSource.None;
  
    // Set the Parameter with appropriate Source Column Name
    cmd.Parameters.Add("@ColumnName", SqlDbType.Varchar, 50,
        mysqlfirstTableRowsTobeCopied.Columns[0].ColumnName);   
    ...
    SqlDataAdapter adpt = new SqlDataAdapter();
    adpt.InsertCommand = cmd;
    // Specify the number of records to be Inserted/Updated in one go. Default is 1.
    adpt.UpdateBatchSize = 20;
    
    conn.Open();
    int recordsInserted = adpt.Update(mysqlfirstTableRowsTobeCopied);   
    conn.Close();
