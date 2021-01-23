    using (SqlCommand command = new SqlCommand("SELECT User, Password 
        FROM UsersData WHERE User=@user and Password=@password", connection))
	    {
		//
		// Add new SqlParameter to the command.
		//
		command.Parameters.Add(new SqlParameter("user ", textbox1.text));
                command.Parameters.Add(new SqlParameter("password", textbox2.text));
		
		SqlDataReader reader = command.ExecuteReader();
                if (reader == null)
		
		{
		  Form1 formload = new Form1();
                  formload.Show();    
		}
                else
                {
                  label3.Text = "Invalid Username or Password !";    
                }
       }
