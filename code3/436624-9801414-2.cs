    public static bool SendGmail(string subject, string content, string[] recipients, string from) {
        if (recipients == null || recipients.Length == 0)
            throw new ArgumentException("recipients");
        var gmailClient = new System.Net.Mail.SmtpClient {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new System.Net.NetworkCredential("******", "*****")
        };
        using (var msg = new System.Net.Mail.MailMessage(from, recipients[0], subject, content)) {
            for (int i = 1; i < recipients.Length; i++)
                msg.To.Add(recipients[i]);
            try {
                gmailClient.Send(msg);
                return true;
            }
            catch (Exception) {
                // TODO: Handle the exception
                return false;
            }
        }
    }
