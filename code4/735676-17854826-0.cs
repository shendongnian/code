    using (var emailServer = new SmtpClient("Server"))
    {
       emailServer.Credentials = new System.Net.NetworkCredential("Username", "Password");
    
       MailMessage email = new MailMessage();
       email.From = new MailAddress("from");
       email.Subject = "Subject";
       email.To.Add(listEmail[iCount]);
    
       emailServer.Send(email);
    }
