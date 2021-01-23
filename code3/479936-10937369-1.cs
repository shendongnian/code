    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string v = System.Configuration.ConfigurationManager.ConnectionStrings["harish"].ConnectionString;
        con = new OracleConnection(v);
        con.Open();
        cmd = new OracleCommand("select * from user_info where username='" + Login1.UserName.Trim() + "' and password='" + Login1.Password + "'", con);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count > 0)
        {
            Response.Redirect("Default2.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
        con.Close();
    }
