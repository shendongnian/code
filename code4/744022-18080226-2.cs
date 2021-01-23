    using (SqlConnection cnn = new SqlConnection(sqlConString))
    {
        var cmds = File.ReadAllText(@"path\to\file").Split(new string[] { "GO" },
            StringSplitOptions.RemoveEmptyEntries);
        cnn.Open();
        foreach (var cmd in cmds)
        {
            using (SqlCommand cmd = new SqlCommand(cmd, cnn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
