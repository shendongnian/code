        public int CreateUser(string UserName,string Pwd)
        {
            int intRowsinserted = 0;
            cmd = new SqlCommand("CreateUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter name = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            name.Value = UserName;
            SqlParameter password = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
            password.Value = Pwd;
            cmd.Connection.Open();
            intRowsinserted = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            conn.Close();
            return intRowsinserted;
        }
