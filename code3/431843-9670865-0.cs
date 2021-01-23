    SqlConnection scon = new SqlConnection(connectionString);
    SqlCommand authCmd = new SqlCommand("AuthenticateUser", scon);
    authCmd.CommandType = System.Data.CommandType.StoredProcedure;
    
    SqlParameter userNameParam = authCmd.Parameters.Add("@AzUserName", System.Data.SqlDbType.VarChar, 20);
                            userNameParam.Value = username;
    string hashed = Zonal.Pie.Core.Common.Utils.Md5Hash.ComputeHash(username);
    
    SqlParameter hashedParam = authCmd.Parameters.Add("@Hash", System.Data.SqlDbType.VarChar, 32);
    hashedParam.Value = hashed;
    
    SqlParameter userIdParam = authCmd.Parameters.Add("@UserId", System.Data.SqlDbType.Int);
    userIdParam.Direction = System.Data.ParameterDirection.Output;
    
    SqlParameter authorizedParam = authCmd.Parameters.Add("@Authorized", System.Data.SqlDbType.Bit);
    authorizedParam.Direction = System.Data.ParameterDirection.Output;
    
    scon.Open();
    authCmd.ExecuteNonQuery();
    //Access authorizedParam.Value and userIdParam.Value here
    scon.Close();
