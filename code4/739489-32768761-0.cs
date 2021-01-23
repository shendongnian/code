    public System.Data.DataTable EmployeeViewAll()
      {
      DataTable dtbl = new DataTable();
      try
      {
      // Here it shuld be your database Connection String
      string connectionString = "Server = .; database = HKS; Integrated Security = true";
     
    using (SqlConnection sqlCon = new System.Data.SqlClient.SqlConnection(connectionString))
      {
      SqlDataAdapter SqlDa = new SqlDataAdapter("employeeViewAll", sqlCon);
      SqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
      SqlDa.Fill(dtbl);
      }
      return dtbl;
      }
      catch (Exception)
      {
      throw;
      }
      }
    
    
      public void ComboFill()
      {
      DataTable dt = new DataTable();
       eSP SP = new eSP();
      d = SP.EmployeeViewAll();
      comboBox1.DataSource = dt;
      comboBox1.DisplayMember = "department";
      comboBox1.ValueMember = "empName";
      }
