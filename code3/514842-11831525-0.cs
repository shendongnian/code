        public static string mailServer = 'IP address or host name of mail server'
        public static void Send()
        {
            string subject = "test subject";
            string address =  "test@somedomain.com";
            string body = "some mail body";
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("no-reply@domain.net"); //on behalf of
            mm.To.Add(new MailAddress(address));
            mm.IsBodyHtml = true;
            mm.Subject = subject;
            mm.Body = body;
            SmtpClient server = new SmtpClient(mailServer);
            server.Send(mm);
        }
    }
