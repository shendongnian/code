    using (var con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  C:\Users\JAY\Desktop\Employee.mdb"))
    using (var cmd = new OleDbCommand("select * from Emp_Details WHERE DOB= ?", con))
    {
        cmd.Parameters.AddWithValue("@P1", monthCalendar1.SelectionRange.Start);
        using (var da = new OleDbDataAdapter(cmd))
        {
            da.Fill(ds, "Emp_Details");
            if (ds.Tables["Emp_Details"] !=null && ds.Tables["Emp_Details"].Rows.Count>0)
            {
                DataRow dr = ds.Tables["Emp_Details"].Rows[0];
                txtEmployeeNo.Text = dr[0].ToString();
                txtName.Text = dr[1].ToString();
                txtAddress.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                txtMobNo.Text = dr[4].ToString();
            }
        }
    } 
