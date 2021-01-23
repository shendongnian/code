	public void SendMailedFilesDKLol() {
		string[] sentFiles=Directory.GetFiles(some_Folder);
		if(sentFiles.Count()>0) {
			System.Net.Mail.SmtpClient client=new System.Net.Mail.SmtpClient("ares");
			System.Net.Mail.MailMessage msg=new System.Net.Mail.MailMessage();
			msg.From=new MailAddress("system@lol.dk");
			msg.To.Add(new MailAddress("lmy@lol.dk"));
			msg.Subject="IBM PUDO";
			msg.Body=
				sentFiles.Count()+" attached file(s) has been sent to the customer(s) in question ";
			msg.IsBodyHtml=true;
			var attachments = sentFiles.Select(f => new Attachment(f)).ToList();
			attachments.ForEach(a => msg.Attachments.Add(a));
			client.Send(msg);
			attachments.ForEach(a => a.Dispose());
		}
	}
