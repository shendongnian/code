    DataTable dt = new DataTable();
    using (MySqlConnection conn = new MySqlConnection("Your connection string"))
    {
        conn.Open();
        string query = "SELECT * FROM table";
        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            da.Fill(dt);
    }
    yourDataGrid.ItemsSource = dt.DefaultView;
