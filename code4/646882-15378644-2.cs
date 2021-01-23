    string val = DropDownList1.SelectedValue.ToString();
    using (SqlConnection con = new SqlConnection(DBcon))
    {
        SqlCommand sqlCommand = new SqlCommand("Select * from tbl_WinApps_FileHeader");
        sqlCommand.Connection = con;
        SqlDataReader read = sqlCommand.ExecuteReader();
        GridView1.DataSource = read;
        GridView1.DataBind();
    }
    
