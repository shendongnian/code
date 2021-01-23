    string password = null;
    using (var conn = new SqlCeConnection("Data Source = 'AlviMBRental.sdf';" + "Password='my Password';"))
    using (var comm = new SqlCeCommand("SELECT Password FROM Admin", conn))
    {
        conn.Open();
        
        using (var reader = comm.ExecuteReader())
        {
            password = (string)reader["Password"];
        }
    }
    MessageBox.Show(password ?? "No password found.");
