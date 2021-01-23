    public static void Send(this MailMessage email)
    {
        if (!isInitialized)
            Initialize(false);
        //smtpClient.SendAsync(email, "");
        email.IsBodyHtml = true;
        Task.Factory.StartNew(() =>
        {
            // Make sure your caller Dispose()'s the email it passes in at some point!
            using (SmtpClient client = new SmtpClient("smtpserveraddress"))
            {
                client.Send(email);
            }
        });
    }
