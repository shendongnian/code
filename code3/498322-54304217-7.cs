    Create public class MailSender : IMailSender
        {
            public MailSender()
            {
               
            }
    
            public void SendConfirmEmail(string emailId, Guid userId)
            {
                var confirmEmail = new ConfirmEmail
                {
                    UserId = userId
                };
                ConfirmEmail(emailId, MailResource.YourRegistration, confirmEmail);
            }
    
            private void ConfirmEmail(string recipient,string subject,ConfirmEmail model)
            {
                var key = Guid.NewGuid();
                var mail = new Mail<ConfirmEmail>("ConfirmEmail", model);
                mail.ViewBag.AddValue("Recipient", recipient);           
                var sentMail = mail.Send(key, recipient, subject);          
            }
        }
	
