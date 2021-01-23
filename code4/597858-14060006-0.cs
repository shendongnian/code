    //Nick's code
    MailMessage mail = new MailMessage("orders@test.com", toAddress, subject, messageBody);
    mail.IsBodyHtml = true;
    //set encoding
    mail.BodyEncoding = Encoding.UTF8; //or SevenBit, etc, whatever is appropriate.
    //send
    SmtpClient client = new SmtpClient(_hostName);
    client.Send(mail);
