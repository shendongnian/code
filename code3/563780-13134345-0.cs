    try
       {
          MailMessage mail = new MailMessage();
          mail.To.Add("sender id");
          mail.From = new MailAddress("your id");   
          mail.Subject = "Mail from my web page";
          mail.Body ="Body Content";
          mail.IsBodyHtml = true;
          SmtpClient smtp = new SmtpClient();
          smtp.Host = "smtp.gmail.com";
          //Or your Smtp Email ID and Password  
          smtp.Credentials = new System.Net.NetworkCredential
          ("XYZ", "XXXXX");
          smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
          smtp.EnableSsl = true;
          smtp.Send(mail);
       }
                        
                     
    catch (Exception ex)
        {
            //display exception             
                        
        }
