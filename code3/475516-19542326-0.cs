     protected void btnSubmit_Click(object sender, EventArgs e)
        {
        try
        {
        MailAddress SendFrom = new MailAddress(txtFrom.Text);
        MailAddress SendTo = new MailAddress(txtTo.Text);
        
        MailMessage MyMessage = new MailMessage(SendFrom, SendTo);
        
        MyMessage.Subject = txtSubject.Text;
        MyMessage.Body = txtBody.Text;
        
        Attachment attachFile = new Attachment(txtAttachmentPath.Text);
        MyMessage.Attachments.Add(attachFile);
        
        SmtpClient emailClient = new SmtpClient(txtSMTPServer.Text);
        emailClient.Send(MyMessage);
        
        litStatus.Text = "Message Sent";
        }
        catch (Exception ex)
        {
        litStatus.Text=ex.ToString();
        }
        }
