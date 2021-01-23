    SqlConnection sqlConnStoredProc = new SqlConnection(MyClass.GlobalConn());
    sqlConnStoredProc.Open();
    SqlCommand cmd = new SqlCommand("dbo.rvk_GetSalesPerItem", sqlConnStoredProc);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@piDateFrom", SqlDbType.Int).Value = FromDT1;
    cmd.Parameters.Add("@piDateThru", SqlDbType.Int).Value = ToDT2;
    cmd.Parameters.Add("@BRANCH", SqlDbType.NVarChar).Value = dRgetAllBranch[1].ToString();
    cmd.Parameters.Add("@brNum", SqlDbType.Int).Value = dRgetAllBranch[0].ToString();
    cmd.Parameters.Add("@PluCode", SqlDbType.NVarChar).Value = str1;
    cmd.ExecuteNonQuery();
    
    sqlConnStoredProc.Close();
