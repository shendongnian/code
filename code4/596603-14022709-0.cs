    var doc = new XDocument(
        new XDeclaration("1.0", "utf-16", "true"),
        new XProcessingInstruction("test", "value"),
        new XElement("Attachments", 
            new XElement("Attachment", 
                new XElement("AttachmentName", attachment.Name),
                new XElement("Subject", exchangeEmailInformation.Subject),
                new XElement("Sender", exchangeEmailInformation.Sender)
        )));
