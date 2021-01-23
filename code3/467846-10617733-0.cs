    [WebMethod]
    public Employee GetEmployeeDetails(string userType)
    {
       //search the data based on the data key in
       string sql = "SELECT * FROM member WHERE userType = '" + ?? + "'";
       SqlCommand cmd = new SqlCommand(sql, conn);
       conn.Open();
       reader = cmd.ExecuteReader();
       if (reader.Read())
       {
          emp=new Employee { fullName = reader["fullName"].ToString(), password =       reader["password"].ToString(), userType= reader["userType"].ToString() 
       }
       
       reader.close();
       return emp;
    }
