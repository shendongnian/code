            string temp = string.Empty;
            string cmdText = "SELECT [LoweredEmail] FROM [vw_aspnet_MembershipUsers] WHERE     ([UserName] = @UserName)"
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = CommandType.Text;
                             cmd.Parameters.AddWithValue(@UserName, UserName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
	                    {
                            temp = reader.GetValue(0).ToString(); // email ID
                        }
                    }
                }
                conn.Close();
