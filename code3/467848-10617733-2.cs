    [WebMethod]
    public List<Employee> GetEmployeeDetails(string userType)
    {
       //search the member table looking for a matching userType value
       string sql = "SELECT * FROM member WHERE userType = '" + ?? + "'";
       SqlCommand cmd = new SqlCommand(sql, conn);
       conn.Open();
       List<Employee> employeeList = new List<Employee>();
       reader = cmd.ExecuteReader();
       while (reader.Read())
       {
          var emp = new Employee(
              { 
                  fullName = reader["fullName"].ToString(), 
                  password = reader["password"].ToString(), 
                  userType = reader["userType"].ToString()
              });
       
          employeeList.Add(emp);
       }
       
       reader.close();
       return employeeList;
    }
