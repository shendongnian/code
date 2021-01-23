    MembershipUser user = Membership.GetUser(userName);
    string password = user.ResetPassword();
    string sQuestion = DropDownList1.SelectedValue.ToString();
    string sAnswer = txtAnswer.Text.ToString();
    user.ChangePasswordQuestionAndAnswer(password, sQuestion, sAnswer);
