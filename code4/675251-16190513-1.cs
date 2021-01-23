    public DataTable SQL_ValidateCheck(string part)
        {
            try
            {
                DataTable tbl_val = new DataTable();
                using (SqlConnection AutoConn = new SqlConnection(conn32))
                {
                    AutoConn.Open();
                    using (SqlCommand InfoCommand = new SqlCommand())
                    {
                        using (SqlDataAdapter infoAdapter = new SqlDataAdapter(InfoCommand))
                        {
                            InfoCommand.Connection = AutoConn;
                            InfoCommand.CommandType = CommandType.StoredProcedure;
                            InfoCommand.CommandText = "dbo.ValidationResults";
                            InfoCommand.Parameters.AddWithValue("@particular", part);
                            InfoCommand.CommandTimeout = 180;
                            infoAdapter.Fill(tbl_val );
                            AutoConn.Close();
                            return tbl_val ;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error in connection :: " + e);
               
                return tbl_val ;
            }
        }
