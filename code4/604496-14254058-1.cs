    ExchangeEmailInformation information = exchangeEmailInformation;
    var emailId = information.Sender.Split('@');
    information.UserAlias = emailId[0];
    foreach (var queueList in exchangeEmailInformation.Attachment)
    {
        var attachment = queueList;
        AddAttachmentAsync(information, attachment);
    }
    // and modify AddAttachmentAsync to pull properties from the right parameter.
