    public int? AddNewDesigDataSql(string desig_name, string Details, int AddedBy)
        {
            int? status = 0;
            DataTable dt = new DataTable();
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                string conString = Connection.GetConnection;
    
                using (SqlConnection con = new SqlConnection(conString))
                {
                    //sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_Dedignation_Add", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        SqlParameter param1=cmd.Parameters.Add("@Desig_Name", SqlDbType.Int).Value = desig_name;
    param1.Direction = ParameterDirection.Input;
    
                        SqlParameter param2=cmd.Parameters.Add("@Desig_Desc", SqlDbType.Int).Value = Details;
    param2.Direction = ParameterDirection.Input;
    
                        SqlParameter param3=cmd.Parameters.Add("@Desig_AddedBy", SqlDbType.DateTime).Value = AddedBy;
    param3.Direction = ParameterDirection.Input;
    
                        SqlParameter param4=cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
    
    param4.Direction = ParameterDirection.Output;
    
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
    
                        status = (int)param4.Value;
    
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dt = ds.Tables[0];
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
    
            }
            return status;
        }
