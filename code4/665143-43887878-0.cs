     SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("From@mail.com", "Fukra@12345");
            MailAddress from = new MailAddress("From Address Ex From@mail.com", String.Empty, System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress("From Address Ex To@mail.com");
            MailMessage message = new MailMessage(from, to);
            message.Body = "This is your body message";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "Subject";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
         
            client.Send(message);
