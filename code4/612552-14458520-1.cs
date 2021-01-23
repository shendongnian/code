    protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
            con.Open();
            SqlCommand cmdr = new SqlCommand("Select name From registration where name = @username and password = @password", con);
            cmdr.Parameters.Add("@username", txt_name.Text.trim());
            cmdr.Parameters.Add("@password", txt_pass.Text.trim());
            SqlDataReader dr = cmdr.ExecuteReader();
            
            if(cmdr.ExecuteReader().HasRows)
            {
                 Response.Redirect("logout.aspx");
                 Session["userName"] = txt_name.Text.trim();
            }
            else{
            //Error page path
            }               
            //DOn't forget to close the connection when you Open it
          con.Close();
        }
