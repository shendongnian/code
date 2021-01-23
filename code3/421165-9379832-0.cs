    SmtpClient smtp = new SmtpClient();
    MailMessage mm = new MailMessage("from address", Membership.GetUser().EmailAddress);
    mm.Subject = "Test";
    mm.Body = "Test";
    smtp.Send(mm);
