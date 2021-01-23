    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
    client.UseDefaultCredentials = false;
    client.Credentials = new NetworkCredential("login", "password");
    client.EnableSsl = true;
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
