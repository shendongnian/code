    string password = null;
    using (var conn = new SqlCeConnection("Data Source = 'AlviMBRental.sdf'; Password='my Password';"))
    using (var comm = new SqlCeCommand("SELECT Password FROM Admin", conn))
    {
        conn.Open();
        
        using (var reader = comm.ExecuteReader())
        {
            password = (string)reader["Password"];
        } // Dispose reader
        // Alternatively, if the resultset is single column and single row, you can do:
        var passwordScalar = (string)comm.ExecuteScalar();
    } // Dispose command, close / dispose connection.
    MessageBox.Show(password ?? "No password found.");
