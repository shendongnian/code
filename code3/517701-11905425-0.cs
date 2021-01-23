            try
            {
                using (SqlConnection cn = new SqlConnection(this.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Insert_User", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cn.State != ConnectionState.Open)
                        cn.Open();
                    cmd.Parameters.Add("Id", SqlDbType.NVarChar).Value = "00A640BD-1A0D-499D-9155-BA2B626D7B68";
                    cmd.Parameters.Add("AccountId", SqlDbType.NVarChar).Value = "DCBA241B-2B06-48D7-9AC1-6E277FBB1C2A";
                    cmd.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = "Mark";
                    cmd.Parameters.Add("LastName", SqlDbType.NVarChar).Value = "Wahlberg";
                    cmd.Parameters.Add("JobTitle", SqlDbType.NVarChar).Value = "Actor";
                    cmd.Parameters.Add("PhoneNumber", SqlDbType.NVarChar).Value = "9889898989";
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
