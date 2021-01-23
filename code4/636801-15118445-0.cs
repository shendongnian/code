    private void btnSignupNew_Click(object sender, EventArgs e)
    {
    
       if (txtUsername.Text == "")
       {
    	   errorUsername.SetError(txtUsername, "Enter A Username");
       }
       else if (txtPassword.Text == "")
       {
    	   errorPassword.SetError(txtPassword, "Enter A Valid Password");
       }
       else
       {
    		using (SqlConnection con = new SqlConnection("Data Source=etc")) 
    		{
    			con.Open();
    			
    			bool exists = false;
    			// create a command to check if the username exists
    			using (SqlCommand cmd = new SqlCommand("select count(*) from [User] where UserName = @UserName", con))
    			{
    				cmd.Parameters.AddWithValue("UserName", txtUsername.Text);
    				exists = (int)cmd.ExecuteScalar() > 0;
    			}
    			// if exists, show a message error
    			if (exists)
    				errorPassword.SetError(txtUsername, "This username has been using by another user.");
    			else 
    			{
                                // does not exists, so, persist the user
    				using (SqlCommand cmd = new SqlCommand("INSERT INTO [User] values (@Forname, @Surname, @Username, @Password)", con))
    				{
    					cmd.Parameters.AddWithValue("Forname", txtForname.Text);
    					cmd.Parameters.AddWithValue("Surname", txtSurname.Text);
    					cmd.Parameters.AddWithValue("UserName", txtUsername.Text);
    					cmd.Parameters.AddWithValue("Password", txtPassword.Text);
    					
    					cmd.ExecuteNonQuery();
    				}				
    			}
    			
    			con.Close();
    		}   
    	}
    }
