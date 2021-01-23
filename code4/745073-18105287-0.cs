            SqlCommand com = new SqlCommand("update_outptu_Stock", connect.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@cg_id ", 1);
                SqlParameter par = new SqlParameter("@id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
