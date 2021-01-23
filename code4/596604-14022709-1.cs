    doc.Root.Add(new XElement("Attachment",
        new XElement("AttachmentName", attachment.Name),
        new XElement("Subject", exchangeEmailInformation.Subject),
        new XElement("Sender", exchangeEmailInformation.Sender)
    ));
