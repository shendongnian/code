    SqlCommand cmd = new SqlCommand("SqlInsert", sqlCon);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@Param1", SqlDbType.VarChar, 25).Value = _sqlComputer ;
    cmd.Parameters.Add("@Param2", SqlDbType.VarChar, 50).Value = _lastUpdatedBy ;
    cmd.Parameters.Add("@Param3", SqlDbType.DateTime).Value = DateTime.Now
    cmd.Parameters.Add("@Param4", SqlDbType.Varchar,50).Value = _softwareName ;
       
    sqlCon.Open();
    SqlDataReader dr = cmd.ExecuteReader();
    DataTable dt = new DataTable();
    dt.Load(dr);
    sqlCon.Close();
    dr.Dispose();
    cmd.Dispose();
