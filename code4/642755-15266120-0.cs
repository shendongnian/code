    using System.Net.Mail;
    public class Email
        {
    
            public MailAddress From { get; set; }
            public MailAddress To { get; set; }
            public string Password { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public string Host { get; set; }
            public int Port { get; set;}
            public List<Attachment> attachmentsList = new List<Attachment>();
    
      
            public void send()
            {
                //send email
                var smtp = new SmtpClient
                {
                    Host = Host,
                    Port = Port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(From.Address, Password),
                    Timeout = 120000 //2mins
                };
    
                MailMessage message = new MailMessage(From.Address, To.Address);
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = true;
    
                foreach(Attachment attachment in attachmentsList){
                    if (attachment != null)
                    {
                        message.Attachments.Add(attachment);
                    }                
                }
    
                try
                {
                    smtp.Send(message);
                }
                catch(Exception e){
    
                    throw e;
                }
            }
        }
