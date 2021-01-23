    using System.Net.Mail;
    using Telerik.Sitefinity.Services;
    using Telerik.Sitefinity.Web.Mail;
    using Telerik.Sitefinity.Configuration;
    
    var smtpSettings = Config.Get<SystemConfig>().SmtpSettings;
    MailDefinition mailDef = new MailDefinition()
    {
    	IsBodyHtml = true,
    	BodyFileName = "~/Files/EmailBody.html",
    	Subject = "Thanks for Commenting!",
    	From = !smtpSettings.DefaultSenderEmailAddress.IsNullOrEmpty() ?  smtpSettings.DefaultSenderEmailAddress : smtpSettings.UserName
    };
    MailMessage email = mailDef.CreateMailMessage(this.EmailControl.Value.ToString(), new ListDictionary(), this);
    EmailSender.Get().Send(email);
