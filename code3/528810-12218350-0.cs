    MembershipCreateStatus status;
        
    MembershipUser membershipUser = System.Web.Security.Membership.CreateUser(
    UsernameTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text, 
    PasswordQuestioTextBox.Text, PasswordAnswerTextBox.Text, true, out status);
        
    // Then assign user to website based on the selected checkboxes
