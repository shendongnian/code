    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Connection String"].ConnectionString);
            con.Open();
            com = new SqlCommand("SELECT * FROM stdtable WHERE matri_perct >  @Percent", con);
            com.Parameters.AddWithValue("@Percent", float.Parse(txtPercent.Text));
            SqlDataReader reader = com.ExecuteReader();  // execute SELECT statement, store result in data reader
            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
             }
        catch (System.Exception err)
        {
            Label1.Text = err.Message.ToString();
        }
    }
