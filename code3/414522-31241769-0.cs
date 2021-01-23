    string your_id = "your_id@gmail.com";
    string your_password = "password";
    try
    {
       SmtpClient client = new SmtpClient
       {
         Host = "smtp.gmail.com",
         Port = 587,
         EnableSsl = true,
         DeliveryMethod = SmtpDeliveryMethod.Network,
         Credentials = new System.Net.NetworkCredential(your_id, your_password),
         Timeout = 10000,
       };
       MailMessage mm = new MailMessage(your_iD, "recepient@gmail.com", "subject", "body");
       client.Send(mm);
       Console.WriteLine("Email Sent");
     }
     catch (Exception e)
     {
       Console.WriteLine("Could not end email\n\n"+e.ToString());
     }
