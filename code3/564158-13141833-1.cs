        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("fromadd");
            mail.To.Add("toadd");
            mail.Subject = "Test Mail";
            mail.Body = "This is for testing SMTP mail from GMAIL";
            SmtpClient SmtpServer = new SmtpClient();            
            SmtpServer.Send(mail);
            MessageBox.Show("mail Send");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
