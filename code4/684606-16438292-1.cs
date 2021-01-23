    public class EmailSender : IEmailSender
    {
        Queue<MailMessage> _messages = new Queue<MailMessage>();
        SmtpClient _client = new SmtpClient();
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
    
            lock (_messages)
            {
                _messages.Enqueue(mailMsg);
                if (_messages.Count == 1)
                {
                    ThreadPool.QueueUserWorkItem(SendEmailInternal);
                }
            }
        }
        protected virtual void SendEmailInternal(object state)
        {
            while (true)
            {
                MailMessage msg;
                lock (_messages)
                {
                    if (_messages.Count == 0)
                        return;
                    msg = _messages.Dequeue();
                }
                _client.Send(msg)
            }
        }
    }
