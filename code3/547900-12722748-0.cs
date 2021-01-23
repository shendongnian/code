    private static void SendReport(Report report)
    {
        MailMessage msg = new MailMessage
        {
            From = new MailAddress(Configuration.EmailFrom),
            Subject = Configuration.EmailSubject,
            Body = Configuration.EmailBody
        };
        msg.To.Add(Configuration.EmailTo);
        if (!string.IsNullOrWhiteSpace(Configuration.EmailCC))
            msg.CC.Add(Configuration.EmailCC);
        if (!string.IsNullOrWhiteSpace(Configuration.EmailBcc))
            msg.Bcc.Add(Configuration.EmailBcc);
        Program.AttachReport(report, msg);
        SmtpClient smtp = new SmtpClient();
        smtp.Send(msg);
    }
    private static void AttachReport(Report report, MailMessage message)
    {
        Stream stream = new MemoryStream();
        report.Save(stream, Configuration.SurveyName);
        message.Attachments.Add(new Attachment(stream, Configuration.AttachmentName, Configuration.AttachmentMediaType));
    }
