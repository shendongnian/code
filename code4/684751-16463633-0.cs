    var recipients = EmailTo.Split(',').ToList();
    if (String.IsNullOrEmpty(EmailFrom))
        EmailFrom = recipients[0];
    MailMessage message = new MailMessage()
    {
        From = new MailAddress(EmailFrom),
        Subject = String.Format("{0:MM-dd-yyyy} Results for task: {1}.", DateTime.Now, Description),
        Body = "Attached is the results file specified for the task: " + Description;
    };
    recipients.ForEach(a => message.To.Add(new MailAddress(a)));
    message.Attachments.Add(new Attachment(LocationOfResults));
    smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
    smtpClient.UseDefaultCredentials = true;
    smtpClient.SendAsync(message, message); // IMPORTANT - send message as UserState so we can access it in the callback
