    DataTable dt = new DataTable();
    using (MySqlConnection conn = new MySqlConnection("Your connection string"))
    {
        conn.Open();
        string query = "SELECT * FROM table";
        using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
            da.Fill(dt);
    }
    yourDataGrid.ItemsSource = dt.DefaultView;
