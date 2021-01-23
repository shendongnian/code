    protected void Send_Button_Click(object sender, EventArgs e)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("One@gmail.com");
        mail.To.Add(new MailAddress("Two@yahoo.com"));
        mail.Bcc.Add(new MailAddress("Three@gmail.com"));
        mail.Subject = "Testing E-mail By ASP.NET";
        mail.Body = "This is only for Demo ";
        if (FileUpload1.HasFile)
        {
            Attachment attach = new Attachment(FileUpload1.PostedFile.InputStream ,FileUpload1.PostedFile.FileName);
            mail.Attachments.Add(attach);
        }
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
        credential.UserName = "One@gmail.com";
        credential.Password = "123456789";
        smtp.Credentials = credential;
        smtp.EnableSsl = true;
        smtp.Send(mail);
    }
