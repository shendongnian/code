    public virtual MailMessage EMailQuote(QuoteData model)
    {
        var mailMessage = new MailMessage { Subject = "..." };
        mailMessage.To.Add(model.Step.EMail);
        mailMessage.To.Add("web@site.com");
        ViewData.Model = model;
        PopulateBody(mailMessage, viewName: "EMailQuote");
        return mailMessage;
    }
