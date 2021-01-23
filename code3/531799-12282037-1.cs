     private void SendMail(string To, string Body)
        {
            SmtpClient Mailing = new SmtpClient("mail.domain.com");
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("mail@domain.com", "Your name or company name");
            Message.Subject = "Subject";
            Message.SubjectEncoding = Encoding.UTF8;
            Message.IsBodyHtml = true;
            Message.BodyEncoding = Encoding.UTF8;
            Message.Body = Body;
            Message.To.Add(new MailAddress(To));
            Mailing.UseDefaultCredentials = false;
            NetworkCredential MyCredential = new NetworkCredential("mail@domain.com", "password");
            Mailing.Credentials = MyCredential; Mailing.Send(Message);
        }
