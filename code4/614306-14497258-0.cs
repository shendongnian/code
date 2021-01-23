    MailMessage mailObj = new MailMessage(strFrom, strTo, strSubject, strBody);
    SmtpClient SMTPObj = new SmtpClient(IPAddress,port);
    try
    {
      SMTPObj.Send(mailObj);
    }
    catch (Exception ex)
    {
      //Handle Exception
    }
