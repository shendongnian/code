    public static IEnumerable<Employee> getAllEmployees()
    {
        string sql = "SELECT EmpID, Name FROM Employee ORDER BY Name";
        using (var con = new SqlConnection(Settings.Default.ConnectionString))
        {
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    var list = new List<Employee>();
                    while (dr.Read())
                    {
                        var emp = new Employee();
                        emp.EmpID = dr.GetInt32(0);
                        emp.Name = dr.GetString(1);
                        list.Add(emp);
                    }
                    return list;
                }
            }
        }
    }
