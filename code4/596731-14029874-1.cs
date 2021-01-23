    protected void ValidateSignUp(object source, ServerValidateEventArgs args)
    {
        bool hasFirstName = txtFirstName.Text.Length > 0 ? true : false;
        bool hasLastName = txtLastName.Text.Length > 0 ? true : false;
        bool hasEmail = txtEmailAddress.Text.Length > 0 ? true : false;
        if (hasFirstName && hasLastName && hasEmail)
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void SignUp(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //All the required fields have been filled in, sign the user up
        }   
    }
