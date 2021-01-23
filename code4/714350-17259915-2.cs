        DataTable t = new DataTable();
        using (SqlConnection c = new SqlConnection(DataConnectionString))
        {
             c.Open();
	         // Create new DataAdapter
	         using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM EmployeeIDs", c))     
             {
                  // Use DataAdapter to fill DataTable
                  a.Fill(t);
             }
	    }
