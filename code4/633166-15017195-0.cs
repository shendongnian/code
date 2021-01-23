    public static bool SendMail(string strFrom, string strTo, string strSubject, string strMsg)
        {            
            try
            {                
                // Create the mail message
                MailMessage objMailMsg = new MailMessage(strFrom, strTo);
                
                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = strSubject;
                objMailMsg.Body = strMsg;
                Attachment at = new Attachment(Server.MapPath("~/Uploaded/txt.doc"));
                objMailMsg.Attachments.Add(at);
                objMailMsg.Priority = MailPriority.High;
                objMailMsg.IsBodyHtml = true;
                //prepare to send mail via SMTP transport
                SmtpClient objSMTPClient = new SmtpClient();
                objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                objSMTPClient.Send(objMailMsg);
                return true;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  
