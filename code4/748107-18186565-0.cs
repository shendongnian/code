    using (SqlConnection con = new SqlConnection(myConnectionString.ConnectionString))
        {
            string query = "Select EmployeeID, (LastName + ','+ FirstName+' '+ MiddleName) as Name from Employee";
            SqlDataAdapter dap = new SqlDataAdapter(query ,con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
             comboBox1.DisplayMember = "Name";
             comboBox1.ValueMember = "EmployeeID";
            comboBox1.DataSource = dt;
           
        }
