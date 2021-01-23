    public static void SendWithSMTP(string name, string pass, string host, int port)
    {
        using (var client = new System.Net.Mail.SmtpClient(host, port))
        {
            client.Credentials = new System.Net.NetworkCredential(name, pass);
            client.EnableSsl = true;
            client.Send("from@example.com", "to@example.com", "This is subject");
        }
    }
