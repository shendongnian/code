    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
        con.Open();
        SqlCommand cmdr = new SqlCommand("Select name,password From registration", con);
        SqlDataReader dr = cmdr.ExecuteReader();
        while (dr.Read())
        {
            if (txt_name.Text == dr[0].ToString() && txt_pass.Text == dr[1].ToString())
            {
                Session["UserName"]=dr[0].ToString(); // OR Session["UserName"]=txt_name.Text;
                Response.Redirect("logout.aspx");
            }
            else
            {
                label4.Text ="Invalid Username/Password";
            }
        }
