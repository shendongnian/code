    using System.Net.Mail;	
		MailMessage mm = new MailMessage("from@here.com", "to@there.com");
		mm.Subject = "some subject";
		mm.IsBodyHtml = true;
		mm.Body = "<span>your html goes here -- for plain text see IsBodyHtml property</span>";			
		SmtpClient client = new SmtpClient();
		client.Send(mm);
