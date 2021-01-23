    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sel = DropDownList1.SelectedValue.ToString();
      //  if (DropDownList1.SelectedIndex == 1)
      //  {
            using (SqlConnection con = new SqlConnection(DBcon))
            {
                SqlCommand sqlCommand = new SqlCommand("Select * from tbl_WinApps_FileHeader");
                sqlCommand.Connection = con;
                SqlDataReader read = sqlCommand.ExecuteReader();
                GridView1.DataSource = read;
                GridView1.DataBind();
            }
        //}
    }
