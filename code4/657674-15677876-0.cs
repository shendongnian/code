    private int IsValidUser()
       {
        int result = 0;
        string strQuery = "Select Email From AUser Where Email = @Email And Password = @Password ";
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        SqlCommand Cmd = new SqlCommand(strQuery, con);
        //Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
        Cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
        con.Open();
        result = (int)Cmd.ExecuteScalar();
        
        if (result > 0)
        {
            //Session["SessionEmail"] = txtEmail.Text;
            Session[General.S_USEREMAIL] = txtEmail.Text;
            Response.Redirect("~/frmMyAccountMyProfile.aspx");
        }
        else
        {
            Literal1.Text = "Invalid Email/Password!";
        }
         return result;
    }
    }
