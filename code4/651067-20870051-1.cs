    private readonly IMailer _mailer;
    
    public MailController(IMailer mailer) {
        _mailer = mailer;
    }
    
    _mailer.SendMail("Forgot", new ForgotModel
    {
        UserName = membershipUser.UserName, 
        Email = user.Email, 
        Password = membershipUser.ResetPassword()
    }, new List<string> { model.Email }, _myEmail, "Your password", new List<string>());
