    string name = User.Identity.Name;
    NCCMembershipProvider u = (NCCMembershipProvider)Membership.Provider;
    
    NCCMembershipUser currentUser = (NCCMembershipUser)u.GetUser(name, true);
    
    currentUser.Salutation = GenderSelect.SelectedValue;
    currentUser.FirstName = TextBoxFirstName.Text;
    currentUser.LastName = TextBoxLastName.Text;
    currentUser.Position = TextBoxPosition.Text;
    // ...
    
    try
    {
        u.UpdateUser(currentUser);
    }
