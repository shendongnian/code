            string oldpass = "somehing";
            string authenid = "pass_to_test";
            string sql = string.Format("select pwd from client where authenid = '{0}' ", authenid);
            string chk = null;
            SqlCommand cmd = new SqlCommand(update, conn);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // has record with username
                chk = reader.GetString(0);
                if (chk.Equals(oldpass))
                {
                    string update = "update client set pwd=@newpass where pwd=@oldpass and authenid=@authenid";
                    cmd.CommandText = update;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@authenid", authenid);
                    cmd.Parameters.AddWithValue("@oldpass", oldpass);
                    cmd.Parameters.AddWithValue("@newpass", newpass);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    return "invalid oldpass";
                }
            }
            else
            {
                // not a valid username
            }
            reader.Close();
            reader.Dispose();
