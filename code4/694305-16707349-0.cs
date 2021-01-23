    try
    {
        ValidateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text);
        Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text);
    }
    catch (MembershipCreateUserException ex)
    {
        ltrStatusMsg.Text = GetErrorMessage(ex.StatusCode);
    }
    catch (ValidationException ex)
    {
        ltrStatusMsg.Text = ex.Message;
    }
    catch (Exception ex)
    {
        // log exception ...
        ltrStatusMsg.Text = "An unexpected error occurred while creating the user";
    }
    ...
    private void ValidateUser(...)
    {
        if (... not valid ...) throw new ValidationException("some suitable message");
    }
