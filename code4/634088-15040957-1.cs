    public static DataTable ExecuteReader (string query,CommandType commType, params SqlParameter[] Paramerters)
    {
       try
       {
          using (SqlConnection conn = new SqlConnection("your connection string here")
          {
              conn.Open();
              using (SqlCommand comm = new SqlCommand(conn,query))
              {
                 conn.CommandType=commType;
                 if (Parameters!=null) comm.Parameters.AddRange(Parameters);
                 DataTable dt = new DataTable();
                 using (SqlDataReader reader = comm.ExecuteReader())
                 {
                    dt.Load(reader);
                 }
                return dt;
             }//end using command
         }//end using connection
    }
     catch(Exception)
    {
             throw;
    }
    }//end function
