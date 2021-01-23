        SqlConnection sqlConn = new SqlConnection(MyClass.GlobalConn());
        sqlConn.Open();
        try
        {
            string getAllBranch = "SELECT iBranch_num,LTRIM(RTRIM(sConstant)) FROM tblgobranch";
            SqlCommand cmdgetAllBranch = new SqlCommand(getAllBranch, sqlConn);
            SqlDataReader dRgetAllBranch=cmdgetAllBranch.ExecuteReader();
              
             
            while (dRgetAllBranch.Read())
            {
                using(var con = new SqlConnection(MyClass.GlobalConn()))
                {
               
                con.Open();
                
                SqlCommand cmd = new SqlCommand("dbo.rvk_GetSalesPerItem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@piDateFrom", SqlDbType.Int).Value = FromDT1;
                cmd.Parameters.Add("@piDateThru", SqlDbType.Int).Value = ToDT2;
                cmd.Parameters.Add("@BRANCH", SqlDbType.NVarChar).Value = dRgetAllBranch[1].ToString();
                cmd.Parameters.Add("@brNum", SqlDbType.Int).Value = dRgetAllBranch[0].ToString();
                cmd.Parameters.Add("@PluCode", SqlDbType.NVarChar).Value = str1;
                cmd.ExecuteNonQuery();
                }
            }
