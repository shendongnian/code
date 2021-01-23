      string connectionString = DAO.GetConnectionString(); 
    SqlConnection sqlConn = new SqlConnection(connectionString);
     sqlConn.Open() 
    strQuery = "update uploadSummaryDB set fileName = @fileName where id in (select max(id) from uploadSummaryDB)"; 
    SqlCommand command = new SqlCommand(strQuery,sqlConn); 
    command.Parameters.Add("@fileName", SqlDbType.NVarChar).Value = file.FileName.ToString(); command.ExecuteNonQuery();
