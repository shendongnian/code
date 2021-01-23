    SqlConnection DbConn = new SqlConnection(YourConnStringHere);
    SqlCommand ExecStoredProc = new SqlCommand();
    ExecStoredProc.CommandType = CommandType.StoredProcedure;
    ExecStoredProc.CommandText = "GetChild";
    ExecStoredProc.Connection = DbConn;
    ExecStoredProc.Parameters.AddWithValue("@ChildID", YourChildId);
    
    using (DbConn)
    {
        DbConn.Open();
        using (SqlDataReader sdr = ExecStoredProc.ExecuteReader())
        {
            while(sdr.Read())
                // reference your column name like this:
                // sdr.GetString(sdr.GetOrdinal("YourColumnName"));
        }
    }
