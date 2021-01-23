        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("mailSMTP.it");
            mail.From = new MailAddress("address.it");
            mail.Subject = "oggetto";
            mail.IsBodyHtml = true;
            string htmlBody = "someHTML";
            mail.Body = htmlBody;
            SmtpServer.Port = 25;
            SmtpServer.EnableSsl = false;
            var index = 0;
            var timer = new System.Threading.Timer((callbackState) =>
                {
                    mail.To.Clear();
                    mail.To.Add(indirizzi[index]);
                    SmtpServer.Send(mail);
                    
                    index++;
                    if (index < indirizzi.Count)
                      timer.Change(3000, Timeout.Infinite);
                    else {
                        timer.Dispose();
                        Invoke(new Action(DisplayAllEmailsSentMessage));
                    }
                }, timer, 3000, Timeout.Infinite);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
