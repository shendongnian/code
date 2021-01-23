    connection.Open(); 
     
 
// Create DbDataReader to Data Worksheet 
    using (DbDataReader dr = command.ExecuteReader()) 
    { 
        // SQL Server Connection String 
        string sqlConnectionString = "Data Source=.; 
           Initial Catalog=Test;Integrated Security=True"; 
 
 
        // Bulk Copy to SQL Server 
        using (SqlBulkCopy bulkCopy = 
                   new SqlBulkCopy(sqlConnectionString)) 
        { 
            bulkCopy.DestinationTableName = "ExcelData"; 
            bulkCopy.WriteToServer(dr); 
        } 
