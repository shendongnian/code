    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
            cmd.Parameters.AddWithValue("@UPassword", txtPWD.Text);
            cmd.Parameters.Add("@OutRes", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
    
            int output = (int)cmd.Parameters["@OutRes"].Value;
            if (output == 1)
            {
                Response.Redirect("Details.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username Or Password')</script>");
            }
