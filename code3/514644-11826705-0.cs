    using (OleDbConnection conn = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString.ToString()))
                    {
                        conn.Open();
                        using (OleDbCommand com = new OleDbCommand("INSERT INTO Workers ( st_login, st_password, st_role ) VALUES (?, ?, ?);", conn))
                        {
                            com.Parameters.AddWithValue("@Login", UserName0.Text);
                            com.Parameters.AddWithValue("@Password", Hashing.Hash(ConfirmPassword0.Text));
                            com.Parameters.AddWithValue("@Role", RoleList1.SelectedValue);
                            com.ExecuteNonQuery();
                        }
                        conn.Close();
