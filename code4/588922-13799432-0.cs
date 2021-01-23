      public DataTable fetchValue()
        {
            SqlDataAdapter dap=new SqlDataAdapter("SELECT * FROM Requisitions;", cn);
            DataSet ds=new();
            dap.Fill(ds);
            return ds.Tables[0];
        }
    
----------
    
            DataTable dtgenerate=new DataTable();
            dtgenerate=fetchValue();
        
           cn.open();
           using (SqlBulkCopy bulkCopy = new SqlBulkCopy(cn))
           {
               bulkCopy.DestinationTableName = "Requisitions";
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
