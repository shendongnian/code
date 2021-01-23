    public List<string> GetDatabaseList()
    {
        List<string> list = new List<string>();
        // Open connection to the database
        string conString = "server=xeon;uid=sa;pwd=manager; database=northwind";
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            // Set up a command with the given query and associate
            // this with the current connection.
            using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(dr[0].ToString());
                    }
                }
            }
        }
        return list;
    }
