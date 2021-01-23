    protected void SendMail()
    {
        var fromAddress = "myemail@gmail.com";
        var toAddress = "myotheremail@gmail.com";
        const string fromPassword = "mypassword";
        string subject = "New Email from Website";
        string body = "From: " + name.Text + "<br/>";
        body += "Email: " + email.Text + "<br/>";
        body += "Message: <br/>" + message.Text + "<br/>";
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        // Passing values to smtp object
        smtp.Send(fromAddress, toAddress, subject, body,IsBodyHtml:true);
    }
