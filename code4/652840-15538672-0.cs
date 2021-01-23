    try
    {
        MailMessage message = new MailMessage();
        SmtpClient smtp = new SmtpClient();
    
        message.From = new MailAddress("from@gmail.com");
        message.To.Add(new MailAddress("to@gmail.com"));
        message.Subject = "Test";
        message.Body = "Content";
    
        smtp.Port = 587;
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("from@gmail.com", "pwd");
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Send(message);
    }
    catch (Exception ex)
    {
        MessageBox.Show("err: " + ex.Message);
    }
