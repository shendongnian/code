    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
    client.UseDefaultCredentials = false;
    client.Credentials = new NetworkCredential("login", "password");
    client.EnableSsl = true;
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
**Update:** as **akiller** correctly suggests, the UseDefaultCredentials property should have been set to false **before** assigning credentials. This is what makes this code work.
