    public SqlConnectionExample()
        {
            // the connection string to the database - this should ALWAYS be configurable
            string connectionString = "server=localhost;initial catalog=mydatabase; user=mysqluser;pass=mysqlpassword";
            int userID = 1; // the ID of the logged in user
            // create a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // create a command to pass over the connection
                using (SqlCommand cmd = new SqlCommand("select connType from login where ID = @id", conn))
                {
                    // create a SQL parameter to add them to the command - this will limit the results to the single user
                    SqlParameter p = new SqlParameter("id", System.Data.SqlDbType.Int);
                    p.Value = userID;
                    cmd.Parameters.Add(p);
                    // as we are only selecting one column and one row we can use ExecuteScalar
                    string connType = cmd.ExecuteScalar().ToString();
                    if (connType.Equals("imap", StringComparison.CurrentCultureIgnoreCase))
                    {
                        // imap
                    }
                    else
                    {
                        // pop3
                    }
                }
            }
        }
