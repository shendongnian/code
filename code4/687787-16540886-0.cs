    public static bool SendMail(string Email, string MailSubject, string MailBody)
    	{
    		bool isSent = false, isMailVIASSL = Convert.ToBoolean(ConfigurationManager.AppSettings["MailServerUseSsl"]);
    
    		string mailHost = ConfigurationManager.AppSettings["MailServerAddress"].ToString(),
    		senderAddress = ConfigurationManager.AppSettings["MailServerSenderUserName"].ToString(),
    		senderPassword = ConfigurationManager.AppSettings["MailServerSenderPassword"].ToString();
    
    		int serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["MailServerPort"]);
    		
    		MailMessage msgEmail = new MailMessage(new MailAddress(senderAddress), new MailAddress(Email));
    		using (msgEmail)
    		{
    			msgEmail.IsBodyHtml = true;
    			msgEmail.BodyEncoding = System.Text.Encoding.UTF8;
    			msgEmail.Subject = MailSubject;
    			msgEmail.Body = MailBody;
    
    			using (SmtpClient smtp = new SmtpClient(mailHost))
    			{
    				smtp.UseDefaultCredentials = false;
    				smtp.EnableSsl = isMailVIASSL;
    				smtp.Credentials = new NetworkCredential(senderAddress, senderPassword);
    				smtp.Port = serverPort;
    				try
    				{
    					smtp.Send(msgEmail);
    					isSent = true;
    				}
    				catch (Exception ex)
    				{
    					throw ex;
    				}
    			}
    		}
    		return isSent;
    	}
