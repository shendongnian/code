		#if DEBUG
		private void SetDebugMode(MailMessage mail) {
		    mail.To.Clear();
			mail.CC.Clear();
			mail.Bcc.Clear();
			mail.To.Add("support@example.com");
			mail.Subject += " [DEBUG]"; }
		#endif
	
		public void SendMail() {
			SmtpClient smtp = new SmtpClient();
			using (MailMessage mail = new MailMessage()) {
			[...]
			#if DEBUG
			SetDebugMode(mail);
			#endif
			smtp.Send(mail); } }
