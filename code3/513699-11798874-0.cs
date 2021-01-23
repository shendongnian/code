        SqlBulkCopy sqlBulk = new SqlBulkCopy(con);
           //Define column mappings 
        for (int i = 0; i < dReader.FieldCount; i++)
        {
            sqlBulk.ColumnMappings.Add(dReader.GetName(i), dReader.GetName(i));
         }
