    public static IList<Employee> GetEmployees(DataTable table)
    {
        var rows = new List<Employee>();
        if (table != null) {
            foreach (DataRow row in table.Rows) {
                var emp = new Employee();
                emp.ID = (int)row["ID"];
                emp.Name = (string)row["Name"];
                emp.Salary = (decimal)row["Salary"];
                rows.Add(emp);
            }
        }
        return rows;
    }
