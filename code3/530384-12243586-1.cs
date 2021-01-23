    private void getData()
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection("YOUR CONNECTION STRING HERE");
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand(" SELECT tbl_staff.staffName,tbl_department.department 
    FROM tbl_staff,tbl_logs,tbl_department 
    WHERE tbl_staff.userID = tbl_logs." + listStaff.SelectedValue + " and tbl_staff.idDepartment = tbl_department.idDepartment", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
    
        sqlCmd.Parameters.AddWithValue("@username",user);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
               lable.Text = dt.Rows[0]["staffName"].ToString(); //Where "staffName" is ColumnName 
             
        }
            connection.Close();
    }
