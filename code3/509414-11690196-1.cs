            //Open a connection to the database using your connection string
            using (SqlConnection con = new SqlConnection("My Configuration string"))
            {
                //Open the connection
                con.Open();
                //Create a new command for the stored proc, using the existing connection just opened
                using(SqlCommand cmd = new SqlCommand("AuthenticateUser", con))
                {
                cmd.CommandType = CommandType.StoredProcedure;
                
                    //Add the username and password to the command, as paramaters (Prevents a lot of security issues, such as SQL Injection)
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 25).Value = UserIdTextBox.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 25).Value = "Password";
                    //A paramater for the return value, which will be a bool (Only 0 or 1 should be returned from the database/stored proc)
                SqlParameter ret = new SqlParameter("ret", SqlDbType.Int);
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                    //Execute the query
                cmd.ExecuteNonQuery();
                if (Convert.ToBoolean(ret.Value) == true)
                {
                    //Login Successful
                }
                else
                {
                    //Login Failed
                }
            }
        }
