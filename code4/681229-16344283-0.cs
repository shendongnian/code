    {
        FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);
        //If user is created, get it by UserName
        MembershipUser createdUser = Membership.GetUser(RegisterUser.UserName);       
        Guid userID = new Guid(createdUser.ProviderUserKey.ToString());
        
        TextBox ImageUrl = RegisterUserWizardStep.ContentTemplateContainer.FindControl("ImageUrl") as TextBox;
        //Use the userID from the above code
        UserProfile.SaveNewProfileInformation(userID, ImageUrl.Text);
    }
