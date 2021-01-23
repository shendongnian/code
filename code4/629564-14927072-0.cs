    string sql = "SELECT value FROM dbo.table WHERE id = @id";
    var pairs = new List<Tuple<int, string>>();
    using (var con = new SqlConnection(yourConnectionString))
    using (var cmd = new SqlCommand(sql, con))
    {
        con.Open();
        foreach (int i in numbers)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", i);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    pairs.Add(Tuple.Create(i, dr.GetString(0)));
                }
            }
        }
    }
