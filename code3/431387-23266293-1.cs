    protected void btnSend_Click(object sender, EventArgs e)
    {
    	try
    	{              
    		MailMessage msg = new MailMessage();
    		msg.From = new MailAddress(txtFrom.Text);                
    		msg.To.Add(new MailAddress(txtTo.Text));
    		msg.Subject = txtSubject.Text;
    		msg.Body = txtBody.Text;                           
    
    		SmtpClient mySmtpClient = new SmtpClient();
    		System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential(txtFrom.Text,txtPwd.Text);
    		mySmtpClient.Host = "smtp.gmail.com";
    		mySmtpClient.Port=587;
    		mySmtpClient.EnableSsl = true;
    		mySmtpClient.UseDefaultCredentials = false;
    		mySmtpClient.Credentials = myCredential;                
    
    		mySmtpClient.Send(msg);
    		msg.Dispose();
    		lberr.Text="Message sent successfully";
    		clrtxt();
    	}
    	catch(SmtpException)
    	{
    		lberr.Text="SMTP Error handled";
    	}
    }
