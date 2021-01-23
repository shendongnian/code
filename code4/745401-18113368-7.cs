     string select = "SELECT * FROM tblEmployee";
     SqlConnection c = new SqlConnection(yourConnectionString); //Your Connection String here
     SqlDataAdapter dataAdapter = new SqlDataAdapter(select, c); 
     SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
     DataSet ds = new DataSet();
     dataAdapter.Fill(ds);
     dataGridView1.ReadOnly = true; 
     dataGridView1.DataSource = ds.Tables[0];
