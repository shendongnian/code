        try
        {
        MailMessage mailMessage = new System.Net.Mail.MailMessage();
        mailMessage.To.Add(userEmailAddress);
        mailMessage.Subject = "Subject";
        mailMessage.Body = "your password should be in this section";
        var smtpClient = new SmtpClient();
        smtpClient.Send(mailMessage);
        return "Mail send successfully";
        }
    
    catch (SmtpException ex)
    {
    return "Mail send failed:" + ex.Message;
    }
