	using System.Net.Mail;
	using System.Web.UI.WebControls;
	// namespace etc
	private void SendEmail()
	{
		string to = "to@somewhere.com,to2@somewhere.com";
		MailDefinition mailDefinition = new MailDefinition();
		mailDefinition.IsBodyHtml = false;
		string host = "smtpserver";  // Your SMTP server name.
		string from = "from@somewhere.com";
		int port = -1;               // Your SMTP port number. Defaults to 25.
		mailDefinition.From = from;
		mailDefinition.Subject = "Boring email";
		mailDefinition.CC = "cc@somwhere.com,cc2@somwhere.com";
		List<System.Net.Mail.Attachment> mailAttachments = new List<System.Net.Mail.Attachment>();
		// Add any attachments here
		using (MailMessage mailMessage = mailDefinition.CreateMailMessage(to, null, "Email body", new System.Web.UI.Control()))
		{
			SmtpClient smtpClient = new SmtpClient(host);
			if (port != -1)
			{
				smtpClient.Port = port;
			}
			foreach (System.Net.Mail.Attachment mailAttachment in mailAttachments)
			{
				mailMessage.Attachments.Add(mailAttachment);
			}
			smtpClient.Send(mailMessage);
		}
	}
