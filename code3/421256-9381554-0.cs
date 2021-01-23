    protected void btnLogin_Click(object sender, EventArgs e)
    {
       string connectionString = ConfigurationManager.ConnectionStrings["moverschoiceConnectionString"].ConnectionString;
       OdbcConnection conn = new OdbcConnection(connectionString);
      conn.Open();
      OdbcCommand cmd = new OdbcCommand();
      cmd.Connection = conn;
      cmd.CommandText = "select Email, Password from brokercenter where Email = '" + txtLoginEmail.Text + "'";
      OdbcDataReader reader = cmd.ExecuteReader();
      While(reader.Read())
      {
        if (reader["Password"].ToString() == txtLoginPassword.Text)
        {
            reader.Close();
            Response.Redirect("BrokerResources.aspx");
        }
        else
        {
            lblLoginError.Text = "Invalid Password";
        }
      }
      lblLoginError.Text = "Invalid Email Address"; 
      reader.Close();
    }
