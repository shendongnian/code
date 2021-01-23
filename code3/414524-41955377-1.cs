	MailMessage mm = new MailMessage(txtEmail.Text, txtTo.Text);
	mm.Subject = txtSubject.Text;
	mm.Body = txtBody.Text;
	if (fuAttachment.HasFile)//file upload select or not
	{
		string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
		mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
	}
	mm.IsBodyHtml = false;
	SmtpClient smtp = new SmtpClient();
	smtp.Host = "smtp.gmail.com";
	smtp.EnableSsl = true;
	NetworkCredential NetworkCred = new NetworkCredential(txtEmail.Text, txtPassword.Text);
	smtp.UseDefaultCredentials = true;
	smtp.Credentials = NetworkCred;
	smtp.Port = 587;
	smtp.Send(mm);
	Response.write("Send Mail");
        
