    bool res=false;
    try
    {
    	using(var connection = new SqlConnection(Properties.Settings.Default.KargarBandarConnectionString))
    	using(var cmd = conn.CreateCommand())
    	{    	
    	    cmd.commandText = "Select IsAdmin from Users where UserName=@UserName And HashedAndSaltedPassword=@PwdHash";
    		cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text.Trim());
    		cmd.Parameters.AddWithValue("@PwdHash", SaltAndHash(PasswordTextBox.Text));		
    		connection.Open();
            var result = cmd.ExecuteScalar();
            if (result!=null)
            {
    			res=bool.Parse(result);		  
    			this.DialogResult = DialogResult.OK;
    		}	
    	}
    }
    catch (Exception ex)
    {	
    	if (progressForm != null){progressForm.Close();}
    	FMessageBox.ShowError(ex.Message);
    }
    
    if(res==false)
    {
        FMessageBox.ShowWarning("error");
        UserNameTextBox.Focus();
    }
