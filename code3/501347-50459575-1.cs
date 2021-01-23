    try
    {
        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        bool enableSSL = true;
        string emailFrom = "senderemail@gmail.com";
        string password = "password";
        string emailTo = "receiver@gmail.com";
        string subject = "Halo!";
        string body = "Halo, Mr. SMTP";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(emailFrom);
        mail.To.Add(emailTo);
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        
        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
        {
            smtp.Credentials = new NetworkCredential(emailFrom, password);
            smtp.EnableSsl = enableSSL;
            smtp.Send(mail);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }
