    private void btnLogin_Click(object sender, EventArgs e)
    {
        // call validate user method and set value to `isValiduser`
        Program.isValiduser= IsValidUser("username", "password"); // here for testing i'm set it as true 
    	if(Program.isValiduser== true)
    	{
    	  this.Close();
    	}
    	else
    	{
    	  //else part code
    	}
    }
