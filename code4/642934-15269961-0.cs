    public void SendMail(string package, string mailTo, string subject, string body) {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(mailAddr, alias);
        mail.Sender = new MailAddress(mailAddr, alias);
        mail.ReplyTo = new MailAddress(mailAddr, alias);
        string[] to = mailTo.Split(new char[] { ',', ';', '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < to.Length; i++) mail.To.Add(to[i]);
        mail.Subject = subject;
        mail.Body = body;
        SmtpClient smtp = new SmtpClient(server, 25);
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("", "", "");
        smtp.EnableSsl = false;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Send(mail);	
	}
