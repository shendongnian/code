    public void GetEmployees() As List<Employee> {
        var employees = new List<Employee>();
        using (var connection = new SqlConnection(Configuration.ConnectionString)) {
            using (var command = connection.CreateCommand()) {
                command.CommandText = "SELECT * FROM dbo.Employee";
                connection.Open();
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        employees.Add(Employee.CreateRecordFromOpenReader(reader));
                    }
                }
            }
        }
        return employees;
    }
