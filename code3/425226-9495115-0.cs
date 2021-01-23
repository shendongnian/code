    private void ListBind(string queryPart)
    {
        SqlDataAdapter adp = new SqlDataAdapter("Retrieve", ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                     DataTable dt = new DataTable();
                     adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                     adp.SelectCommand.Parameters.AddWithValue("s1",queryPart);
                     adp.SelectCommand.Parameters.AddWithValue("s2",DropDownList1.SelectedItem.ToString());
                     adp.Fill(dt);
                     ListBox1.DataSource = dt ;
                     ListBox1.DataBind();
    }
