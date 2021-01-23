    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    string s = DropDownList1.SelectedValue.ToString();
    SqlConnection con = new SqlConnection(
        ConfigurationManager.ConnectionStrings["ztvConnectionString"].ConnectionString);
    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Table1 where name=@name", con);
    cmd.Parameters.Add("@name", s);
    DataTable dt = new DataTable();
    da.Fill(dt);
    GridView1.DataSource = dt;
    GridView1.DataBind();
    }
