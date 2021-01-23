    const string DatabasePath = @"C:\DbPath\MyDatabase.mdb";
    const string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                    DatabasePath;
    
    using (OleDbConnection cnn = new OleDbConnection(ConnectionString)) {
        string query = "SELECT * FROM qryFoo";
        using (OleDbCommand cmd = new OleDbCommand(query, cnn)) {
            cnn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader()) {
                int employeeIdOrdinal = reader.GetOrdinal("EmployeeID");
                int nameOrdinal = reader.GetOrdinal("Name");
                int salaryOrdinal = reader.GetOrdinal("Salary");
                while (reader.Read()) {
                    Console.WriteLine("EmployeeID = {0}", reader.GetInt32(employeeIdOrdinal));
                    Console.WriteLine("Name = {0}", reader.GetString(nameOrdinal));
                    if (!reader.IsDBNull(salaryOrdinal)) {
                        Console.WriteLine("Salary = {0}", reader.GetDouble(salaryOrdinal));
                    }
                    Console.WriteLine("---------------");
                }
            }
        }
    }
