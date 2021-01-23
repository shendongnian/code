Just one thing to add to @keyboardP's comment even though it is a bit out of context, if you are using MailMessage object to be sent as a message using SmtpClient, you need to set the MailMessage.IsBodyHtml = true.
        public void SendEmail(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage("someone@example.com", to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
        ...
        }
