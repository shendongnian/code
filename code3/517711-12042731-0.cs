    protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
    {
        e.Cancel = true;
    }
    bool IsValidEmail(string strIn)
    {
        // Return true if strIn is a valid e-mail
        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }
    protected void SubmitLinkButton_Click(object sender, EventArgs e)
    {
        if (IsValidEmail(PasswordRecovery1.UserName))
        {
            // Get user collection by shared email
            MembershipUserCollection users = Membership.FindUsersByEmail(PasswordRecovery1.UserName);
            if (users.Count < 1)
            {
                PasswordRecovery1.UserName = " ";
                PasswordRecovery1.UserNameFailureText = "That user is not available";
            }
            else
            {
                // Loop and email each user in collection
                foreach (MembershipUser user in users)
                {
                    MembershipUser ur = Membership.GetUser(user.UserName);
                    DateTime now = DateTime.Now;
                    // Using MailDefinition instead of MailMessage so we can substitue strings
                    MailDefinition md = new MailDefinition();
                    // list of strings in password.txt file to be replace
                    ListDictionary replacements = new ListDictionary();
                    replacements.Add("<%UserName%>", ur.UserName);
                    replacements.Add("<%Password%>", ur.GetPassword());
                    // Text file that is in html format
                    md.BodyFileName = "absolute path to password.txt";
                    md.IsBodyHtml = true;
                    md.Priority = MailPriority.High;
                    md.Subject = "Email Subject Line - " + now.ToString("MM/dd - h:mm tt");
                    md.From = ConfigurationManager.AppSettings["FromEmailAddress"];
                    // Add MailDefinition to the MailMessage
                    MailMessage mailMessage = md.CreateMailMessage(ur.Email, replacements, this);
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromEmailAddress"], "Friendly Name");
                    SmtpClient m = new SmtpClient();
                    m.Host = "127.0.0.1";
                    m.Send(mailMessage);
                    PasswordRecovery1.UserName = user.UserName;
                    PasswordRecovery1.SendingMail += PasswordRecovery1_SendingMail;
                }
            }
        }
        else
        {
            PasswordRecovery1.UserName = " ";
            PasswordRecovery1.UserNameFailureText = "Please enter a valid e-mail";
        }
    }
