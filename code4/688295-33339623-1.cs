    protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=D1-0221-37-393\\SQLEXPRESS;Initial Catalog=RSBY;User ID=sa;Password=BMW@721");
            conn.Open();
            string EmployeeId = Convert.ToString(TextBox1.Text);
            string EmployeeName = Convert.ToString(TextBox2.Text);
            string EmployeeDepartment = Convert.ToString(DropDownList1.SelectedValue);
            string EmployeeDesignation = Convert.ToString(DropDownList2.SelectedValue);
            string DOB = Convert.ToString(TextBox3.Text);
            string DOJ = Convert.ToString(TextBox4.Text);
            SqlCommand cmd = new SqlCommand("insert into Employeemaster values('" + EmployeeId + "','" + EmployeeName + "','" + EmployeeDepartment + "','" + EmployeeDesignation + "','" + DOB + "','" + DOJ + "')", conn);
            cmd.ExecuteNonQuery();
           
        }
