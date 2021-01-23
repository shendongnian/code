    public void EmailSend(string subject, string host, string from, string to, string body, int port, string username, string password, bool enableSsl)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(host);
                mail.Subject = subject;
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Body = body;
                smtpServer.Port = port;
                smtpServer.Credentials = new NetworkCredential(username, password);
                smtpServer.EnableSsl = enableSsl;
                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
