    using (MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString))
    using (MySqlDataAdapter da = new MySqlDataAdapter())
    using (DataTable dt = new DataTable()) {
        ...
    }
