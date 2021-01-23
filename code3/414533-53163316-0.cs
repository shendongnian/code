        public async Task SendAsync(string subject, string body, string to)
        {
            using (var message = new MailMessage(smtpConfig.FromAddress, to)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                using (var client = new SmtpClient()
                {
                    Port = smtpConfig.Port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = smtpConfig.Host,
                    Credentials = new NetworkCredential(smtpConfig.User, smtpConfig.Password),
                })
                {
                    await client.SendMailAsync(message);
                }
            }                                     
        }
