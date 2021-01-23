    public void SendAutomatedEmail(string htmlString, string subject, string from, string fromPwd, string recipient)
        {
            try
            {
                string mailServer = "xxxxExchangesver.com";
                string[] allToAddresses = recipient.Split(";,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                MailMessage message = new MailMessage(from, allToAddresses[0]);
                int mailcount1 = 1;
                for (; mailcount1 < allToAddresses.Length; mailcount1++)
                {
                    if (allToAddresses[mailcount1].Trim() != "")
                        message.To.Add(allToAddresses[mailcount1]);
                }
                message.IsBodyHtml = true;
                message.Body = htmlString;
                message.Subject = subject;
                message.CC.Add(from);
                SmtpClient client = new SmtpClient(mailServer);
                var AuthenticationDetails = new NetworkCredential(from, fromPwd);
                client.Credentials = AuthenticationDetails;
                client.EnableSsl = true;
                client.Send(message);
                client.Dispose();
            }
            catch (Exception e)
            {
                status(e.Message, Color.Red);
            }
        }
