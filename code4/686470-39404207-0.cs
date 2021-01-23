    SqlConnection cn = new SqlConnection(ConnectionString.GetConnection()))
                
        {
                 
       cn.Open();
        
                    SqlTransaction transction = cn.BeginTransaction();
                    SqlDataAdapter sda= new SqlDataAdapter("Select * From TableName", cn);
                    sda.SelectCommand.Transaction = transction; 
                    sda.Fill(ds, "TableName");
     transction.Commit();
    
                    
         }
