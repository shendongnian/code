        public bool ExecuteReader(string user_txt)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = GetConnectionString();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from xyz where UserName = @UserID", con);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@UserID";
            param.Value = user_txt;
            cmd.Parameters.Add(param);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return true;
            else
                return false;
        }
