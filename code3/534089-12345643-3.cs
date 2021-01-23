    SmtpClient client = new SmtpClient();
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.EnableSsl = true;
    client.Host = "smtp.gmail.com";
    client.Port = 587;
