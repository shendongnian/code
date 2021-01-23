    using (SqlConnection sc = new SqlConnection())
    {
        sc.ConnectionString = _sqlConnectionString;
        sc.Open();
        string commanda = "SELECT Moneda, SimbolMoneda FROM NomMoneda WHERE Moneda != '' AND SimbolMoneda != ''";
        SqlCommand command = new SqlCommand(commanda, sc);
        command.CommandType = System.Data.CommandType.Text;
        IDataReader reader;
        reader = command.ExecuteReader();
    }
