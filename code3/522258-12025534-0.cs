    @using System.Net.Mail;
    @{
    	if (IsPost)
    	{
            var email = Request["Email"];		
            var subject = Request["Subject"];		
            var message = Request["Message"];		
            using (var client = new SmtpClient())
            {
                 var msg = new MailMessage();
                 msg.To.Add(email);
                 msg.Subject = subject;
                 msg.Body = message;
                 client.Send(msg);
                 <text>The email has been successfully sent</text>
             }
         }
    }
    
    <form action="" method="post">
        <p>Please contact us</p>
        <input type="text" name="email" maxlength="30" value="to@gmail.com" />
        <input type="text" name="subject" maxlength="30" value="Subject" />
        <textarea name="message" cols="30" rows="10"></textarea>
        <input type="submit" value="Send" class="submit" />
    </form>
