        public SmtpClient client = new SmtpClient();
        public MailMessage msg = new MailMessage();
        public System.Net.NetworkCredential smtpCreds = new System.Net.NetworkCredential("mail", "password");
        public void Send(string sendTo, string sendFrom, string subject, string body)
        {
            try
            {
                //setup SMTP Host Here
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = smtpCreds;
                client.EnableSsl = true;
                //converte string to MailAdress
                MailAddress to = new MailAddress(sendTo);
                MailAddress from = new MailAddress(sendFrom);
                //set up message settings
                msg.Subject = subject;
                msg.Body = body;
                msg.From = from;
                msg.To.Add(to);
                // Enviar E-mail
                client.Send(msg);
            }
            catch (Exception error)
            {
                MessageBox.Show("Unexpected Error: " + error);
            }
        }
