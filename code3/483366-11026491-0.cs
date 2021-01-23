        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                u = GetUserFromReader(reader);
                
                reader.Close();
                if (userIsOnline)
                {
                    SqlCommand updateCmd = new SqlCommand("UPDATE Users " +
                        "SET LastActivityDate = @LastActivityDate " +
                        "WHERE Email = @Email AND ApplicationName = @ApplicationName", conn);
                    updateCmd.Parameters.Add("@LastActivityDate", SqlDbType.DateTime).Value = DateTime.Now;
                    updateCmd.Parameters.Add("@Email", SqlDbType.VarChar, 255).Value = username;
                    updateCmd.Parameters.Add("@ApplicationName", SqlDbType.VarChar, 255).Value = m_ApplicationName;
                    updateCmd.ExecuteNonQuery();
                }
            }
            else
            {
                reader.Close()
            }
        }
