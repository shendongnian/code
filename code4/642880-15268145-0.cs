        public static void login(string UserName, string password)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            try
            {
                con.Open();
                string selectstr = "select count(id) from Registration  where UserName=@username And  Password=@password";
                SqlCommand cmd = new SqlCommand(selectstr, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                int result = cmd.ExecuteScalar();
                cmd.Dispose();
                con.Close();
                if (result == 1)
                {
                    label.Text = "valid";
                    //valid
                }
                else
                {
                    //not
                }
            }
            catch
            {
                throw;
            }
        }
