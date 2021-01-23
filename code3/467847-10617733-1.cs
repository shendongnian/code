    [WebMethod]
    public List<Employee> GetEmployeeDetails(string userType)
    {
       //search the data based on the data key in
       string sql = "SELECT * FROM member WHERE userType = '" + ?? + "'";
       SqlCommand cmd = new SqlCommand(sql, conn);
       conn.Open();
       List<Employee> employeeList=new List<Employee>();
       reader = cmd.ExecuteReader();
       while (reader.Read())
       {
          emp=new Employee({ fullName = reader["fullName"].ToString(), password 
          =reader["password"].ToString(), userType= reader["userType"].ToString()});
       
          employeeList.Add(emp);
       }
       
       reader.close();
       return employeeList;
    }
