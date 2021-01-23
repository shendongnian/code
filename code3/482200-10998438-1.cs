           if(Date is null)
           {
             com.Parameters.AddWithValue("@datapubl", emptyDate == null ? DBNull.Value (object)emptyDate);
           }
           else
           {
             com.Parameters.AddWithValue("@datapubl", [Your Date Variable Here]);
           }
