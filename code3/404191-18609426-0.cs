    EmailMessage message = new EmailMessage(service);
    message.Body = txtMessage;
    message.Subject = txtSubject;
    message.Sender= txtFrom;
    ....
    message.SendAndSaveCopy();
