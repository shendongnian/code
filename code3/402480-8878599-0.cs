    System.Web.Mail.MailMessage mailMsg = new System.Web.Mail.MailMessage();
    // ...
    mailMsg.Fields.Add
                ("http://schemas.microsoft.com/cdo/configuration/smtpusessl",
                     true);
