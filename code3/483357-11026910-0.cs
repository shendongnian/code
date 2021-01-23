    private void btnLogin_Click(object sender, EventArgs e)
    {
        // call validate user method and set value to `isValiduser`
        isValiduser = true; // here for testing i'm set it as true 
    	if(isValiduser == true)
    	{
    	  this.Close();
    	}
    	else
    	{
    	  //else part code
    	}
    }
