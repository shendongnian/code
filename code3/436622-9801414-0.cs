        public static bool SendGmail(string subject, string content, string[] recipients, string from)
        {
            bool success = recipients != null && recipients.Length > 0;
            if (success)           
            {
                SmtpClient gmailClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("******", "*****")             
                };
                using (MailMessage gMessage = new MailMessage(from, recipients[0], subject, content))
                {
                    for (int i = 1; i < recipients.Length; i++)
                        gMessage.To.Add(recipients[i]);
                    try
                    {
                        gmailClient.Send(gMessage);
                        success = true;
                    }
                    catch (Exception) { success = false; }
                }
            }
            return success;
        }
    }
