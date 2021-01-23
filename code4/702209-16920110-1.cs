     private void sendmail_Click(object sender, EventArgs e)
        {
            try
            {
                
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("blabla@gmail.com");
                mail.To.Add("mom@gmail.com");
                mail.Subject = "something";
                mail.Body = "text that is in the mail";
    //for attachements
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(str);
                mail.Attachments.Add(attachment);
    //end attachement
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential"username from gmail", "password from gmail");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                MessageBox.Show("Mail Send");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
