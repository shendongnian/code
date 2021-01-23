    using (SqlConnection con = new SqlConnection(myConnectionString.ConnectionString))
        {
            string query = "Select EmployeeID, (LastName + ','+ FirstName+' '+ MiddleName) as Name from Employee";
            SqlDataAdapter dap = new SqlDataAdapter(query ,con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
             comboBox1.DisplayMember = "Name";
             comboBox1.ValueMember = "EmployeeID";
            DataRow dr = dt.NewRow();
            dr[0] = -1;
            dr[1] = "Add Employee";
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt;
           
        }
