      System.Net.NetworkCredential ncred = new System.Net.NetworkCredential(EmailFrom, EmailPass);
    
      MailMessage mail = new MailMessage(EmailFrom, EmailTo, Subject, BodyText);
    
      SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                        {
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = ncred,
                            Timeout = 20000,
                        };
     client.SendCompleted += completeHandler;
     client.SendAsync(mail, "email");
