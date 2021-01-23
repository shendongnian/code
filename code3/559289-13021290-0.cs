    MembershipCreateStatus status;
    
    var membershipUser = Membership.CreateUser(..., out status);
    
    if (status == MembershipCreateStatus.Success)
      SendEmail(...);
    
    
    public void SendEmail(MailAddress from, MailAddress to, 
      string subject, string body)
    {
      var message = new MailMessage();
    
      message.From = from;
      message.To.Add(to);
    
      message.Subject = subject;
      message.Body = body;
      message.IsBodyHtml = true;
    
      var smtpClient = new SmtpClient("localhost");
      smtpClient.Send(message);
    }
