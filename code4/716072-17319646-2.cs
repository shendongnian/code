    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
    {
        conn.Open();
        using (var trans = conn.BeginTransaction())
        using (SqlCommand comm = new SqlCommand("select * from test", conn, trans))
        {
            using (var reader = comm.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    if ((string)reader[1] == "stop")
                    {
                        throw new Exception("Stop was found");
                    }
                }
            }
            trans.Commit();
        }
    }
