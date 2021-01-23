    public DataSet userRoleDropDown()
    {
        string connectionSrting = ConfigurationManager.ConnectionStrings["BugReports"].ConnectionString;        
        string queryString = "SELECT UserRoleID, UserRoleName FROM userRoles";
       using (SqlConnection connection = new SqlConnection(connectionSrting))
       {
          SqlDataAdapter adapter = new SqlDataAdapter();
          adapter.SelectCommand = new SqlCommand( queryString, connection);
          adapter.Fill(dataset);
          return dataset;
       }
    } 
