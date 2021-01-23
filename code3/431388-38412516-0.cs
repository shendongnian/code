    public void SendMail()
    {
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(MailTo.Text);
        mail.From = new MailAddress(MailFrom.Text,"Invoice");
        mail.Subject = Subject.Text;
        mail.Body = Body.Text;
        mail.IsBodyHtml = true;
        string FileName = Path.GetFileName(FileUploadAttachments.PostedFile.FileName);
        Attachment attachment = new Attachment(FileUploadAttachments.PostedFile.InputStream ,FileName);
        mail.Attachments.Add(attachment);            
        
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential("Your_Email@Email.com", "Your_Email_Password");
        client.Host = "smtpout.secureserver.net";
        client.Port = 80;
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);
        }
    }
