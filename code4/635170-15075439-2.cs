    private void FillAdapter()
    {
    	using (SqlConnection conn = new SqlConnection(Your ConnectionString))
    	{
    	  conn.Open();
              using (SqlDataAdapter dataAdapt = new SqlDataAdapter("SELECT * FROM EmployeeIDs", conn))
          {
    	     DataTable dt = new DataTable();
    	     dataAdapt.Fill(dt);
    	    // dataGridView1.DataSource = dt;//if you want to display data in DataGridView 
          }
        }
    }
