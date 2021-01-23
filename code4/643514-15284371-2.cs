        public static bool SendMail(string to, string subject, string body)
        {
            bool result;
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("your email address")
                };
                mailMessage.To.Add(new MailAddress(to));
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                var userName = "your gmail username";
                var password = "your gmail password here";
                var smtpClient = new SmtpClient
                {
                    Credentials = new NetworkCredential(userName, password),
                    Host = smtp.gmail.com,
                    Port = 587,
                    EnableSsl = true
                };
                smtpClient.Send(mailMessage);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
