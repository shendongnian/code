            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            service.Credentials = new WebCredentials("user1", "1234", "domain.com");
            service.AutodiscoverUrl("user2@domain.com");
            EmailMessage email = new EmailMessage(service);
            email.ToRecipients.Add("user2@domain.com");
            email.Subject = "HelloWorld";
            email.Body = new MessageBody("Sent by using the EWS Managed API");
            //save it first!
            email.Save(new FolderId(WellKnownFolderName.Drafts, "user1@domain.com"));
            email.Send();
