    protected void RegisterUser_CreatingUser(object sender, EventArgs e)
    {
        TextBox _txtEmailAddress = (TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Email");
        Label _lblEmailAddress = (Label)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("lblEmail");
        // Set the email property of the CreateUserWizard control to append the domain
        RegisterUser.Email = _txtEmailAddress.Text + _lblEmailAddress.Text;
    }
