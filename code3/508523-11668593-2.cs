        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="strTo">The STR to.</param>
        /// <param name="strFrom">The STR from.</param>
        /// <param name="strSubject">The STR subject.</param>
        /// <param name="strMessage">The STR message.</param>
        /// <param name="strAttachment">The STR attachment.</param>
        /// <param name="strBCC">The STR BCC.</param>
        /// <returns></returns>
        private string SendMessage(string strTo, string strFrom, string strSubject, string strMessage, string strAttachment, string strBCC)
        {
            try
            {
                string strEmail = string.Empty;
                string strSmtpClient = ConfigurationManager.AppSettings["SmtpClient"];
                string[] arrEmailAddress = strTo.Split(';');
                foreach (string emailAddress in arrEmailAddress)
                {
                    if (!string.IsNullOrEmpty(emailAddress.Trim()))
                    {
                        using (System.Net.Mail.MailMessage mailMsg = new MailMessage(strFrom, strEmail, strSubject, strMessage))
                        {
                            mailMsg.IsBodyHtml = true;
                            if (!string.IsNullOrEmpty(strBCC))
                                mailMsg.Bcc.Add(strBCC);
                            if (!string.IsNullOrEmpty(strAttachment))
                            {
                                System.Net.Mail.Attachment attachment;
                                attachment = new System.Net.Mail.Attachment(strAttachment);
                                mailMsg.Attachments.Add(attachment);
                            }
                            using (System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(strSmtpClient))
                            {
                                smtpClient.UseDefaultCredentials = true;
                                smtpClient.Port = 25;
                                smtpClient.Send(mailMsg);
                            }
                        }
                    }
                }
                return string.Format("Message sent to {0} at {1}.", strTo, DateTime.Now);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
