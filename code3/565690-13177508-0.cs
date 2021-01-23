    //you can try by using the following smtp configuration in web.config
    
    <system.net>
        <mailSettings>
          <smtp>
            <network host="SMTPServer" port="" userName="username" password="password" />
          </smtp>
        </mailSettings>
      </system.net>
      <appSettings>
        <add key="Email" value="you@yourwebsite.com"/>
      </appSettings>
    
    //where host=your server name, port=server machines port number
    
    //and in code behind write the code as follows:
    
           string fromEmail = ConfigurationManager.AppSettings["Email"].ToString();
    	string toEmail = txtEmail.Text;
    	MailMessage message = new MailMessage(fromEmailAddress, toEmailAddress);
    	message.Subject = txtSubject.Text;
    	message.Body = txtBody.Text;
    
    	SmtpClient smtp = new SmtpClient();
    	smtp.Send(message);
