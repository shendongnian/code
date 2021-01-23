    void RegisterUserWizard_CreatingUser(object sender, LoginCancelEventArgs e)
    {
        // If we have received an error message in the Context then cancel the CreatingUser and display the message
        if (Context.Items["ErrorMessage"] != null)
        {
            CustomValidator custValidator = (CustomValidator)RegisterUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("CustomValidator");
            custValidator.ErrorMessage = Context.Items["ErrorMessage"].ToString();
            custValidator.IsValid = false;
            e.Cancel = true;
        }
    }
