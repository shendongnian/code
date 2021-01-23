    protected void BtnChangePassword_Click(object sender, EventArgs e)
    {
      String connectionStringFormat = "Data Source={0};User Id={1};Password={2};pooling=false;";
      if (Page.IsValid)
      {
        Boolean hasHasError = false;
        String connectionString = String.Format(
          connectionStringFormat,
          IptDatabase.Text,
          IptUserName.Text,
          IptOldPassword.Text);
        OracleCommand cmd = new OracleCommand();
        using (cmd.Connection = new OracleConnection(connectionString))
        {
          try
          {
            cmd.Connection.Open();
          }
          catch (OracleException ex)
          {
            //allow to continue if the password is simply expired, otherwise just show the message
            if (ex.Number != 28001)
            {
              ShowErrorMessage(ex.Message);
              hasHasError = true;
            }
          }
    
          if (!hasHasError)
          {
            //successful authentication, open as password change account
            cmd.Connection.Close();
            cmd.Connection.ConnectionString = ConfigurationManager.ConnectionStrings[IptDatabase.Text].ConnectionString;
            cmd.Connection.Open();
            cmd.CommandText = "SysChangePassword";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("username", IptUserName.Text);
            cmd.Parameters.Add("newpassword", IptPassword.Text);
            try
            {
              cmd.ExecuteNonQuery();
              ShowInfoMessage("Password Changed");
            }
            catch (OracleException ex)
            {
              ShowErrorMessage(ex.Message);
            }
    
    
          }
        }
      }
