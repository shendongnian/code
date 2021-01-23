    private void button1_Click(object sender, EventArgs e)
    {
        connString = "Server=sql.byethost46.org;Port=3306;Database=bleachon_aza;UID=bleachon;password=********";
        using (conn = new MySqlConnection(connString))
        {
            string query = "INSERT into users (Username, password) VALUES (@usr, @pass)";
            // are you sure your column name is Username and not username ?
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand(conn, query))
            {
                cmd.Parameters.AddWithValue("@usr", usr.Text);
                cmd.Parameters.AddWithValue("@pass", pass.Text); 
                cmd.ExecuteNonQuery();
                // No need to close your connection. The using statement will do that for you.
            }
        }
    }
