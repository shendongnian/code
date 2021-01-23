    ExchangeEmailInformation information = exchangeEmailInformation;
    var emailId = information.Sender.Split('@');
    information.UserAlias = emailId[0];
    foreach (var queueList in exchangeEmailInformation.Attachment)
    {
        AddAttachmentAsync(information, queueList.Name, queueList.Size);
    }
    // and modify AddAttachmentAsync to use these two parameters too
