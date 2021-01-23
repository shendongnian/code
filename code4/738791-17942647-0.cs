        var list = new List<Myclassdef>();
        using (var con = new SqlConnection(Settings.Default.ConnectionString))
        {
            using (var cmd = new SqlCommand("SELECT ... WHERE Col1=@param1", con))
            {
                cmd.Parameters.AddWithValue("@aram1", "value1");
                // ...
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Myclassdef data = new Myclassdef();
                        data.Data = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            data.Data.Add(reader.GetName(i), reader[i]);
                        }
                        list.Add(data);
                    }
                }
            }
        }
