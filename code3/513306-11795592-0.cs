    public class Email
    {
    	public Email(string recieverAdress)
    	{
    		mail = new MailMessage(senderAdress, recieverAdress);
    	}
    
    	private readonly MailMessage mail;
    	private readonly SmtpClient smtpClient = new SmtpClient("smtp.domain.com", port);
    	private readonly NetworkCredential credential = new NetworkCredential("username", "password");
    
    	public void SendMail(string subject, string textInBody)
    	{
    		mail.Subject = DateTime.Now + " " + subject;
    		mail.Body = textInBody;
    		smtpClient.Credentials = credential;
    		smtpClient.Send(mail);
    	}
    }
