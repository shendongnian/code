     public static bool SaveDetails(DataTable dbTable)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=akshay;Initial Catalog=CosmosDB;User Id=sa;Password=Nttdata123");
                conn.Open();
                SqlBulkCopy sbc = new SqlBulkCopy(conn);
    
                
                if (dbTable.Rows.Count > 0)
                {
                    sbc.DestinationTableName = "Employee";
                    sbc.WriteToServer(dbTable);              
    
    
                }
    
                sbc.Close();
                conn.Close();
    
    
                return true;
    
    
    
            }
            catch (Exception exp)
            {
               
                return false;
            }
    
        }
