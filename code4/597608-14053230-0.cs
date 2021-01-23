        string host = "xxx";
        string str2 = "xxx";
        string userName = "xxx";
        string password = "xxx";
        SmtpClient client = new SmtpClient(host) {
            Port = 0x1b,
            Credentials = new NetworkCredential(userName, password)
        };
        MailAddress from = new MailAddress(str2, userName, Encoding.UTF8);
        MailAddress to = new MailAddress(mTo);
        MailMessage message = new MailMessage(from, to) {
            IsBodyHtml = true,
            Body = mBody,
            Subject = mSubject
        };
        client.Send(message);
        return "email sent";
    }
