     private bool isAdmin(string username)
     {
        string connString = "Data Source=appSever\\sqlexpress;Initial Catalog=TestDB;Integrated Security=True";
        string cmdText = "SELECT ID, NetID FROM dbo.Admins WHERE NetID = @NetID)";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            // Open DB connection.
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                cmd.Parameters.AddWithValue("@NetID", NetID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                    if (reader.Read())
                        if (reader["ID"].Equals(1))
                            return true;
                return false;
            }
        }
     }
