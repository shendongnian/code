    using System.Net.Mail;
    public int SendMailUsingGMAIL(string fromAddress, string toAddress, string tocc, string mailsubject, string msgContent, string strAttachment, bool isBodyHTML)
    {
        int retvar = 0;
        try
        {
         
            MailMessage mailMessage = new MailMessage(new MailAddress(fromAddress)
                                                , new MailAddress(toAddress));
            mailMessage.Subject = mailsubject;
            mailMessage.IsBodyHtml = isBodyHTML;
            mailMessage.Body = msgContent;
            if (tocc != "")
            {
                mailMessage.CC.Add(tocc);
            }
            System.Net.NetworkCredential networkCredentials = new
            System.Net.NetworkCredential("smtpUserName", "smtpPassword");//key="smtpUserName" value="urid@gmail.com";key="smtpPassword" value="your password"
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = networkCredentials;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.Send(mailMessage);
           
        }
        catch (Exception ex)
        {
            retvar = -1;
        }
        return retvar;
    }
