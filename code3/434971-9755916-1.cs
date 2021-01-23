    public static void SendWithSMTP(string name, string pass, string host, int port)
    {
        using (var client = new System.Net.Mail.SmtpClient(host, port))
        {
            client.Credentials = new System.Net.NetworkCredential(name, pass);
            client.EnableSsl = true;
            MailMessage mail = new MailMessage("from@ex.com","to@ex.com",head, body);
            mail.Attachments.Add(new Attachment("specify your attachment path"));
            client.Send(mail);
        }
    }
