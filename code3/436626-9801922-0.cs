                this.client = new SmtpClient(_account.SmtpHost, _account.SmtpPort);
                this.client.EnableSsl = _account.SmtpUseSSL;
                this.client.Credentials = new NetworkCredential(_account.Username, _account.Password);
            try
            {
                // Create instance of message
                MailMessage message = new MailMessage();
                // Add receivers
                for (int i = 0; i < email.Receivers.Count; i++)
                    message.To.Add(email.Receivers[i]);
                // Set sender
                message.From = new MailAddress(email.Sender);
                // Set subject
                message.Subject = email.Subject;
                // Send e-mail in HTML
                message.IsBodyHtml = email.IsBodyHtml;
                // Set body of message
                message.Body = email.Message;
                //validate the certificate
                ServicePointManager.ServerCertificateValidationCallback =
                delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
                // Send the message
                this.client.Send(message);
                // Clean up
                message = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send e-mail. Exception caught: " + e);
            }
