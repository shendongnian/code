    public Task SendPhotos(string fileNameToSend)
    {
        try
        {
            MailAddress from = new MailAddress("username", "User " + (char)0xD8 + " Name", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress("myrmail");
            var photosmessage = new MailMessage(from, to);
            photosmessage.Body = "Please check the log file attachment i have some bugs.";
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            photosmessage.Body += Environment.NewLine + someArrows;
            photosmessage.BodyEncoding = System.Text.Encoding.UTF8;
            photosmessage.Subject = "Log File For Checking Bugs" + someArrows;
            photosmessage.SubjectEncoding = System.Text.Encoding.UTF8;
            Attachment myAttachment = new Attachment(fileNameToSend, MediaTypeNames.Application.Octet);
            photosmessage.Attachments.Add(myAttachment);
            SmtpClient photossend = new SmtpClient("smtp.gmail.com", 587);
            photossend.EnableSsl = true;
            photossend.Timeout = 10000;
            photossend.DeliveryMethod = SmtpDeliveryMethod.Network;
            photossend.UseDefaultCredentials = false;
            photossend.Credentials = new NetworkCredential("user", "pass");
            SendLogFile.Enabled = false;
            return photossend.SendMailAsync(photosmessage);
        }
        catch (Exception errors)
        {
            Logger.Write("Error sending message :" + errors);
            return Task.FromResult<object>(null);
        }
    }
