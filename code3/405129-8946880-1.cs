    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
    //smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    smtp.Credentials = new NetworkCredential(GoogleUserEmail, GooglePassword);
    smtp.EnableSsl = true;
    // smtp.UseDefaultCredentials = true;
    if (attachments != null && attachments.Length > 0)
            {
                foreach (String a in attachments)
                {
                    message.Attachments.Add(new Attachment(a));
                }
            }
            try
            {
                smtp.Send(message);
            }
            
