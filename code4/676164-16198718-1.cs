	MailMessage msg = new MailMessage();
	msg.From = new MailAddress("fromAddr");
	msg.To.Add(anAddr);
	
	if (File.Exists(fullExportPath))
	{
		Attachment mailAttachment = new Attachment(fullExportPath); //attach
		msg.Attachments.Add(mailAttachment);
		msg.Subject = "Subj";
		msg.IsBodyHtml = true;
		msg.BodyEncoding = Encoding.ASCII;
		msg.Body = "Body";
		sendMail(msg);
	}
	else
	{
		//handle missing attachments
	}
