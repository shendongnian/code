      public DataTable fetchValue()
        {
            SqlDataAdapter dap=new SqlDataAdapter("SELECT RequisitionId,CreatedBy,DateCreated,AircraftTailNum,JobNumber,ShopCode,RequestedByName,RequestedById,Status,IsCancelled,IsProcessed FROM Requisitions;", cn);
            DataSet ds=new();
            dap.Fill(ds);
            return ds.Tables[0];
        }
    
----------
    
            DataTable dtgenerate=new DataTable();
            dtgenerate=fetchValue();
        
           cn.open();
           using (SqlBulkCopy bulkCopy = new SqlBulkCopy(n))
           {
               bulkCopy.DestinationTableName = "Requisitions";//DestionTableName
               // bulkCopy.ColumnMappings.Add("SourceColumnIndex", "DestinationColumnIndex");  
               bulkCopy.ColumnMappings.Add("RequisitionId", "RequisitionId");
               bulkCopy.ColumnMappings.Add("CreatedBy", "CreatedBy");
               bulkCopy.ColumnMappings.Add("DateCreated", "DateCreated");
               bulkCopy.ColumnMappings.Add("AircraftTailNum", "AircraftTailNum");
               bulkCopy.ColumnMappings.Add("JobNumber", "JobNumber");
               bulkCopy.ColumnMappings.Add("ShopCode", "ShopCode");
               bulkCopy.ColumnMappings.Add("RequestedByName", "RequestedByName");
               bulkCopy.ColumnMappings.Add("RequestedById", "RequestedById");
               bulkCopy.ColumnMappings.Add("Status", "Status");
               bulkCopy.ColumnMappings.Add("IsCancelled", "IsCancelled");
               bulkCopy.ColumnMappings.Add("IsProcessed", "IsProcessed");
    
               bulkCopy.WriteToServer(dtgenerate);
           }
           cn.close();
