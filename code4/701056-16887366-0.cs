    private static void _loadSqlCommand(List<string> args, object[] values, SqlCommand cm)
    {
        for (int i = 0; i < args.Count; i++)
        {
            // This line:
            cm.Parameters.AddWithValue(args[i], values[i].ToString());
        }
    }
