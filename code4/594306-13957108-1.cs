    using (SqlConnection conn = new SqlConnection("Data Source=xx.xx.x.xx;Initial Catalog=tablenamae;User ID=xxx;Password=xxxxxxx"))
    {
        DataTable dt = new DataTable();
    
        conn.Open();
    
        SqlCommand cmd = new SqlCommand("GetStudentInfo", conn);
    
        cmd.CommandType =CommandType.StoredProcedure;
    
        cmd.Parameters.Add(new SqlParameter("@ID", AdminDropDown.SelectedValue));
    
        //cmd.Connection.Open();
        //cmd.ExecuteNonQuery();
    
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
    
        ad.Fill(dt);     
    
        if (dt.Rows.Count > 0)
        {
            //If you want to get mutiple data from the database then you need to write a simple looping
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
    
            txtMiddleName.Text = dt.Rows[0]["MiddleName"].ToString();
    
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
    
            txtSignature.Text = dt.Rows[0]["Signature"].ToString();
    
        }
    
        ad.Dispose();  // e.g. this way
    
        cmd.Connection.Close();
    }
