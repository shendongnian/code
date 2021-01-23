    public static void SendWithSMTP(string username, string password, string host, 
        int port)
    {
        using (var client = new System.Net.Mail.SmtpClient(host, port))
        {
            client.Credentials = new System.Net.NetworkCredential(username, password);
            client.EnableSsl = true;
            client.Send("from@example.com", "to@example.com", "This is a test subject.", 
                "This is a test email message body.");
        }
    }
