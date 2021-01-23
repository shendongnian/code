    string s = DropDownList1.SelectedValue.ToString();
    //SqlConnection...
    SqlCommand cmd = new SqlCommand("SELECT * FROM Table1 WHERE depat = @depat", conn)
    cmd.Parameters.Add("@depat", SqlDbType.NVarChar);
    cmd.Parameter["@depat"].Value = s;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    da.Fill(dt);
    
    GridView1.DataSource = dt;
    GridView1.DataBind();
