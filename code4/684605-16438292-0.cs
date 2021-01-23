    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {
        }
    
        public void SendMail(MailAddress fromMailAddress, string to, string subject, string body, bool highPriority)
        {
            if (fromMailAddress == null)
                throw new ArgumentNullException("fromMailAddress");
            if (to == null)
                throw new ArgumentException("No valid recipients were supplied.", "to");
    
            // Mail initialization
            var mailMsg = new MailMessage
            {
                From = fromMailAddress,
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                Priority = (highPriority) ? MailPriority.High : MailPriority.Normal
            };
    
            mailMsg.To.Add(to);
    
            using (var smtp = new SmtpClient())
                smtp.Send(mailMsg);
        }
    }
