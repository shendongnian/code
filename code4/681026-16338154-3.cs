    Overig(String sqlCom, string UpdatedBy, DateTime dat, string software)
    {
    SqlCommand cmd = new SqlCommand("SqlInsert", sqlCon);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@Param1", SqlDbType.VarChar, 25).Value = sqlCom;
    cmd.Parameters.Add("@Param2", SqlDbType.VarChar, 50).Value = UpdatedBy;
    cmd.Parameters.Add("@Param3", SqlDbType.DateTime).Value = dat
    cmd.Parameters.Add("@Param4", SqlDbType.Varchar,50).Value = software;
       
    sqlCon.Open();
    SqlDataReader dr = cmd.ExecuteReader();
    DataTable dt = new DataTable();
    dt.Load(dr);
    sqlCon.Close();
    dr.Dispose();
    cmd.Dispose();
     }
