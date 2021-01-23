    using System.Net.Mail;	
		MailMessage mm = new MailMessage("from@here.com", "to@there.com");
		mm.Subject = "some subject";
		mm.IsBodyHtml = true;
		mm.Body = "content of email body here";
					
		SmtpClient client = new SmtpClient();
		client.Send(mm);
