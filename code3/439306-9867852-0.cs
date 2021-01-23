    var list = from c in context.Emails orderby c.EmailAddress select c.EmailAddress;
    MailMessage mail = new MailMessage();
    try
    {
    
        mail.From = new MailAddress(txtfrom.Text);
        foreach (var c in list)  
        {  
            mail.To.Add(new MailAddress(c.ToString()));
        }
        mail.Subject = txtSub.Text;
        mail.IsBodyHtml = true;
        mail.Body = txtBody.Text;
        if (FileUpload1.HasFile)
        {
            mail.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
        }
        SmtpClient smtp = new SmtpClient();
        smtp.Send(mail); 
    }
    catch (Exception)
    {
        //exception handling
    }
