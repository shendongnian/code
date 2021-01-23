	public void sendMail(MailMessage msg)
	{
		string username = "username";  //email address or domain user for exchange authentication
		string password = "password";  //password
		SmtpClient mClient = new SmtpClient();
		mClient.Host = "mailex.company.us";
		mClient.Credentials = new NetworkCredential(username, password);
		mClient.DeliveryMethod = SmtpDeliveryMethod.Network;
		mClient.Timeout = 100000;
		mClient.Send(msg);
	}
