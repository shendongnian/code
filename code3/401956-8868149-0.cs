        /// <summary>
        /// Send an Email
        /// </summary>
        /// <param name="host">Example: smtp.gmail.com</param>
        /// <param name="port">Port to send email</param>
        /// <param name="from">Example: Email@gmail.com</param>
        /// <param name="password">Password</param>
        /// <param name="toList">List of people to send to</param>
        /// <param name="subject">Subject of email</param>
        /// <param name="messsage">Meddage of emial</param>
        /// <param name="deliveryMethod">Deliever type</param>
        /// <param name="isHtml">Is email HTML</param>
        /// <param name="useSSL">Is email SSL</param>
        /// <param name="ccList">List of people to cc</param>
        /// <param name="atachmentList">List of attachment files</param>
        public void SendMessage(string host, int port, string from, string password, List<string> toList, string subject, string messsage,
            SmtpDeliveryMethod deliveryMethod, bool isHtml, bool useSSL, List<string> ccList, List<string> atachmentList)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(host);
                smtpClient.DeliveryMethod = deliveryMethod;
                smtpClient.Port = port;
                smtpClient.EnableSsl = useSSL;
                if (!string.IsNullOrEmpty(password))
                    smtpClient.Credentials = new NetworkCredential(from, password);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(from);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = isHtml;
                mailMessage.Body = messsage;
                if (toList != null)
                {
                    for (int i = 0; i < toList.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(toList[i]))
                            mailMessage.To.Add(toList[i]);
                    }
                }
                if (ccList != null)
                {
                    for (int i = 0; i < ccList.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(ccList[i]))
                            mailMessage.CC.Add(ccList[i]);
                    }
                }
                if (atachmentList != null)
                {
                    for (int i = 0; i < atachmentList.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(atachmentList[i]))
                            mailMessage.Attachments.Add(new Attachment(atachmentList[i]));
                    }
                }
                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
