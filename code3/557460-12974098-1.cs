        DataSet ds = new DataSet("TimeRanges");
        using(SqlConnection conn = new SqlConnection("ConnectionString"))
        {               
                sqlComm = new SqlCommand("Procedure1", conn);               
                sqlComm.Parameters.AddWithValue("@Start", StartTime);
                sqlComm.Parameters.AddWithValue("@Finish", StartTime);
                sqlComm.Parameters.AddWithValue("@TimeRange", TimeRange);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                                
                da.Fill(ds);
         }
          
