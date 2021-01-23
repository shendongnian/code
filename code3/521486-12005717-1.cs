    protected void RegisterUser_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        if (companyddl.SelectedValue == ""){
             errorlbl.Text = "Please Select A Company You Will Be Ordering Parts From.";
             return;
        }
        MembershipCreateStatus createStatus = new MembershipCreateStatus();
        MembershipUser newUser = System.Web.Security.Membership.CreateUser(RegisterUser.UserName, RegisterUser.Password, RegisterUser.Email, RegisterUser.Question, RegisterUser.Answer, true, out createStatus);
    
        if (companyddl.SelectedValue == "SF")
            Roles.AddUserToRole(RegisterUser.UserName, "user_sf");
        if (companyddl.SelectedValue == "TL")
            Roles.AddUserToRole(RegisterUser.UserName, "user_tl");
        if (companyddl.SelectedValue == "" && companytxt.Text != "OurCompany")
            Roles.AddUserToRole(RegisterUser.UserName, "user");
        if ((companytxt.Text == "OurCompany" || companytxt.Text == "OurCompany, Inc.") && companyddl.SelectedValue == "")
            Roles.AddUserToRole(RegisterUser.UserName, "manager");
        
    }
