    private void SaveData(string sys, string dia, string pulse)
    {
        try
        {
            string connectionString = @"Data Source=(local);AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\spiediena_merisana.mdf;Integrated Security=True;User Instance=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               string queryString = "INSERT INTO merisana1 (sys, dia, pulse) VALUES (@sys, @dia, @pulse)";
               SqlCommand command = new SqlCommand (queryString, connection);        
               
               command.Parameters.AddWithValue("@sys", sys);
               command.Parameters.AddWithValue("@dia", dia);
               command.Parameters.AddWithValue("@pulse", pulse);
               command.connection.Open();
               command.ExecuteNonQuery();
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
