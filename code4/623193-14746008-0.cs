        public void SendMail()
    {
    	MailMessage msg = new MailMessage();
    	msg.From = new MailAddress("contact@yourwebsite.com");
    	string s = txtEmail.Text;
    	msg.To.Add(txtEmail.Text);
    	msg.Body = "<html><body><img src='~/images/back.png'/><br></body></html>";
    	msg.IsBodyHtml = true;
    	msg.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
    	Attachment at = new Attachment(Server.MapPath("~/Main/images/English.pdf"));
    	//Dim at1 As New Attachment(Server.MapPath("~/Main/images/English.pdf"))
    	msg.Attachments.Add(at);
    	//msg.Attachments.Add(at1)
    	msg.Priority = MailPriority.High;
    	msg.Subject = "Special Gift";
    	SmtpClient smtp = new SmtpClient();
    	smtp.Host = "smtp.gmail.com";
    	smtp.EnableSsl = true;
    	smtp.Credentials = new System.Net.NetworkCredential("yourgmail@gmail.com", "gmailpassword");
    	smtp.Send(msg);
    }
