      private int TryToAddUser(string UserName)
            {
                int res = 0;
                try
                {
                    string sQuery = " IF NOT EXISTS (select * from users where username = @username) \n\r" + 
                    " BEGIN \n\r" + 
                    "     INSERT INTO users values (@username) \n\r" + 
                    " SELECT SCOPE_IDENTITY() \n\r " + 
                    " END \n\r " + 
                    " ELSE SELECT 0";
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                    {
                        cmd.CommandText = sQuery;
                        cmd.Parameters.AddWithValue("@username",UserName);
                        cmd.Connection = new System.Data.SqlClient.SqlConnection("SomeSqlConnString");
                        cmd.Connection.Open();
                        res = (int)cmd.ExecuteScalar();
                        cmd.Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return res;
            }
