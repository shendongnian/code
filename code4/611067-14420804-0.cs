    public static void SendMessage(String server, String[] emails, String subject, String body)
    {
        MailMessage message = new MailMessage(m_Sender, String.Join(",", emails), subject, body);
        SmtpClient client = new SmtpClient("mail.smtp.com");
        client.Credentials = CredentialCache.DefaultNetworkCredentials;
        try { client.Send(message); }
        catch (Exception ex) { Console.WriteLine("ERROR!"); }
    }
