    using (SmtpClient client = new SmtpClient("smtp-server.MyDomain.com"))
    {
        client.UseDefaultCredentials = true;
    
        using (MailMessage mail = new MailMessage())
        {
            mail.Subject = subject;
            mail.Body = body;
    
            mail.From = new MailAddress("MyEmail@MyDomain.com");
            mail.To.Add("ToThisEmail@MyDomain.com");
    
            client.Send(mail);
        }
    }
