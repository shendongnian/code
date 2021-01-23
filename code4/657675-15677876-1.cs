    protected void btnSignIn_Click(object sender, EventArgs e)
     {
        // Authenticate User
        int blnValidUser = IsValidUser();
        //Check if blnValidUser is greater than 0.
        //IsValidUser() will return value greater than 0 if the sql is successful else will return 0
        if (blnValidUser > 0)
        {
            // on Success - If remember me > Save to cookies
            //SaveUserDetailsToCookie();                       
        }
        else
        {
            // on Failure - Show error msg
        }
    }
