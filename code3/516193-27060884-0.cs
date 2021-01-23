    MailMessage mail = new MailMessage();
    mail.From = new MailAddress(CurrentUser.email);
    mail.Subject = txtSubject.Text;
    mail.Body = txtMailBody.Text;
    try
    {
        foreach (ListItem user in lbSelectedUsr.Items)
        { 
            mail.To.Add(new MailAddress(user.email));
        }
        SmtpClient mailClient = new SmtpClient("smtp.host.com");
        mailClient.EnableSsl = true
        mailClient.Send(mail);
        lblResultOK.Visible = true;
    }
    catch(Exception ex)
    {
        lblResultKO.Visible = true;
    }
