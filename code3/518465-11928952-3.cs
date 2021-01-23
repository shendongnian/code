    public string EncryptString(string val)
                {
                    SqlConnection sqlconn = new SqlConnection("conn_string");
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlconn;
    
                    cmd.CommandText = "ng_encryptString"; // This is the sproc which will encrypt the string
                    cmd.CommandType = CommandType.StoredProcedure;
    
                    SqlParameter param1 = cmd.Parameters.Add("inpuStr", SqlDbType.VarChar, 500);
                    param1.Direction = ParameterDirection.Input;
                   
                    SqlParameter param3 = cmd.Parameters.Add("@encryptedStr", SqlDbType.VarChar, 2000);
                    param3.Direction = ParameterDirection.Output;
    
                    param1.Value = val;
                   
                    cmd.ExecuteNonQuery();
                    sqlconn.Close();
                    return (string)param3.Value;
         
                }
