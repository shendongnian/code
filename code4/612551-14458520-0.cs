    protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
            con.Open();
            SqlCommand cmdr = new SqlCommand("Select name,password From registration where name = @username", con);
            cmdr.Parameters.Add("@username", txt_name.Text.trim());
            
            SqlDataReader dr = cmdr.ExecuteReader();
            while (dr.Read())
            {
                if (txt_name.Text.trim() == dr[0].ToString() && txt_pass.Text.trim() == dr[1].ToString())
                {
                    Response.Redirect("logout.aspx");
                    Session["userName"] = txt_name.Text.trim();
                }
                else
                {
                    label4.Text ="Invalid Username/Password";
                }
            }
          con.Close();
        }
