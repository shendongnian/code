    MailMessage message = new MailMessage();
    message.From = new MailAddress("Abc@Servername.com");
    message.To.Add("Tosender@Servername.com");
    message.Subject = "Your QR Code Image";
    message.Body = "Please open this link and download this QR Code image for scanning your QRCode :" + QR_Code;
    SmtpClient client = new SmtpClient();
    client.EnableSsl = true;
    client.Send(message);
