        DataSet ds = new DataSet("TimeRanges");
        using(SqlConnection conn = new SqlConnection("ConnectionString"))
        {               
                SqlCommand sqlComm = new SqlCommand("Procedure1", conn);               
                sqlComm.Parameters.AddWithValue("@Start", StartTime);
                sqlComm.Parameters.AddWithValue("@Finish", FinishTime);
                sqlComm.Parameters.AddWithValue("@TimeRange", TimeRange);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                                
                da.Fill(ds);
         }
          
