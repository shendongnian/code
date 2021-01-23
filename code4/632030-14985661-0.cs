    public void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
       var fNameTextBox = (TextBox)CreateUserWizardStep1
              .ContentTemplateContainer.FindControl("FName");
       var lNameTextBox = (TextBox)CreateUserWizardStep1
              .ContentTemplateContainer.FindControl("LName");
       var usernameTextBox = (TextBox)CreateUserWizardStep1
              .ContentTemplateContainer.FindControl("UserName");
    
       MembershipUser user = Membership.GetUser(usernameTextBox.Text);
       Guid userId = (Guid)user.ProviderUserKey;
    }
