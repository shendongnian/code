    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
    {
        conn.Open();
        using (SqlCommand comm = new SqlCommand("select * from test", conn))
        {
            using (var reader = comm.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    if ((string)reader[1] == "stop")
                    {
                        throw new Exception("Stop was found");
                    }
                }
            }
        }
    }
