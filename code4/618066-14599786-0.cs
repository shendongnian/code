    private MailMessage GetHtmlEmail()
    {
        MailMessage mail = new MailMessage();
        XmlTextReader xReader = new XmlTextReader(Server.MapPath("~/ConfigFiles/Email.xml"));
        while (xReader.Read())
        {
            switch (xReader.Name)
            {
                case "ToAddress":
                    mail.To.Add(xReader.ReadElementContentAs(typeof(string), null).ToString());
                    break;
                case "FromAddress":
                    mail.From = new MailAddress(xReader.ReadElementContentAs(typeof(string), null).ToString());
                    break;
                case "Subject":
                    mail.Subject = xReader.ReadElementContentAs(typeof(string), null).ToString();
                    break;
                case "EmailBody":
                    mail.Body = xReader.ReadElementContentAs(typeof(string), null).ToString();
                    break;
                default:
                    break;
            }
        }
        return mail;
    }
