      MailRepository rep = new MailRepository("imap.gmail.com", 993, true, @"username", "password");
        foreach (ActiveUp.Net.Mail.Message email in rep.GetUnreadMails("Inbox"))
        {
            System.Web.HttpContext.Current.Response.Write(string.Format("<p>{0}: {1}</p><p>{2}</p>", email.From, email.Subject, email.BodyHtml.Text));
        }
