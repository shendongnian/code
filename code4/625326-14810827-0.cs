                SqlConnection con = new SqlConnection(GetConnectionString());
                con.Open();
                SqlCommand cmd = new SqlCommand("CheckUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("username", username.Text);
                SqlParameter p2 = new SqlParameter("password", password.Text);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                SqlDataReader rd = cmd.ExecuteReader();
                if(rd.HasRows)
                {
                    //do the things
                }
                else
                {
                    lblinfo.Text = "abc";
                }
