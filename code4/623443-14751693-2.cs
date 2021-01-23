    void Application_Start(object sender, EventArgs e)
    {
        Task beginSendEmailTask = new Task(SendEmailRunningTask);
        beginSendEmailTask.Start();
    }
    void SendEmailRunningTask()
    {
        while (true)
        {
            Thread.Sleep(300000); // 5minutes
            MailMessage[] emails = GetEmailsToSend();
            SmtpClient client = new SmtpClient(); // Configure this
            foreach (MailMessage email in emails) 
            {
                client.Send(email);
            }
        }
    }
