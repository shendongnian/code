    using (SqlConnection cnn = new SqlConnection(sqlConString))
    {
        var cmds = File.ReadAllText().Split(new string[] { "GO" },
            StringSplitOptions.RemoveEmptyEntries);
        foreach (var cmd in cmds)
        {
            using (SqlCommand cmd = new SqlCommand(cmd, cnn))
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
