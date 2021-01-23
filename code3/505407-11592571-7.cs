    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
         string country_id =  DropDownList1.SelectedValue;
         BindStatesByCountry(country_id);
    }
    protected void methodsri(string countryId) //change this to BindStatesByCountry
    {
        string s1 = "data source=ALOK-PC\\SQLEXPRESS;database=MySite;integrated security=true";
        SqlConnection con = new SqlConnection(s1);
        con.Open();
        string s2 = "select * from country_states where country_id=@countryId";
        SqlCommand cmd = new SqlCommand(s2, con);
        cmd.Parameters.AddWithValue("@countryId", countryId);
        SqlDataReader dr = cmd.ExecuteReader();
        DropDownList2.DataTextField = "name";
        DropDownList2.DataValueField = "name";
        DropDownList2.DataSource = dr;
        DropDownList2.DataBind();
        con.Close();
        dr.Close();
    }
