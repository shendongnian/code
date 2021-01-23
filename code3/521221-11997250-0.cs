    ThreadPool.QueueUserWorkItem(delegate {
        SmtpClient client = new SmtpClient();
        // Set up the message here
        using (MailMessage msg = new MailMessage()) {
            client.Send(msg);
        }
    });
