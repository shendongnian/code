    private void button1_Click(object sender, EventArgs e)
    {
        var connectionString = "Data Source='AlviMBRental.sdf';Password='my Password';";
        using (var con = new SqlCeConnection(connectionString))
        using (var cmd = con.CreateCommand())
        {
            con.Open();
            cmd.CommandText = "SELECT Password FROM Admin";
            using (var reader = cmd.ExecuteReader())        
            {
                if (reader.Read())
                {
                    MessageBox.Show(reader["Password"].ToString())
                }
            }
        }
    }
