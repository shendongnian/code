    using System.Net;
    using System.Net.Mail;
     
    public void SendTextMessage(string subject, string message, long telephoneNumer)
            {
                // login details for gmail acct.
                const string sender = "me@gmail.com";
                const string password = "mypassword4gmailacct";
     
                // find the carriers sms gateway for the recipent. txt.att.net is for AT&T customers.
                string carrierGateway = "txt.att.net";
     
                // this is the recipents number @ carrierGateway that gmail use to deliver message.
                string recipent = string.Concat(new object[]{
                telephoneNumer,
                '@',
                carrierGateway
                });
     
                // form the text message and send
                using (MailMessage textMessage = new MailMessage(sender, recipent, subject, message))
                {
                    using (SmtpClient textMessageClient = new SmtpClient("smtp.gmail.com", 587))
                    {
                        textMessageClient.UseDefaultCredentials = false;
                        textMessageClient.EnableSsl = true;
                        textMessageClient.Credentials = new NetworkCredential(sender, password);
                        textMessageClient.Send(textMessage);
                    }
                }
            }
 
