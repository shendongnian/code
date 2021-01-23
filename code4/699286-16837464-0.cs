    /// <summary>
    /// Send Email 
    /// </summary>
    /// <param name="strFrom"></param>
    /// <param name="strTo"></param>
    /// <param name="strSubject"></param>
    /// <param name="strBody"></param>
    /// <param name="strAttachmentPath"></param>
    /// <param name="IsBodyHTML"></param>
    /// <returns></returns>
    public Boolean sendemail(String strFrom, string strTo, string strSubject, string strBody, string strAttachmentPath, bool IsBodyHTML)
    {
        Array arrToArray;
        char[] splitter = { ';' };
        arrToArray = strTo.Split(splitter);
        MailMessage mm = new MailMessage();
        mm.From = new MailAddress(strFrom);
        mm.Subject = strSubject;
        mm.Body = strBody;
        mm.IsBodyHtml = IsBodyHTML;
        //mm.ReplyTo = new MailAddress("replyto@xyz.com");
        foreach (string s in arrToArray)
        {
            mm.To.Add(new MailAddress(s));
        }
        if (strAttachmentPath != "")
        {
            try
            {
                //Add Attachment
                Attachment attachFile = new Attachment(strAttachmentPath);
                mm.Attachments.Add(attachFile);
            }
            catch { }
        }
        SmtpClient smtp = new SmtpClient();
        try
        {
            smtp.Host = ConfigurationManager.AppSettings["MailServer"].ToString();
            smtp.EnableSsl = true; //Depending on server SSL Settings true/false
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["MailUserName"].ToString();
            NetworkCred.Password = ConfigurationManager.AppSettings["MailPassword"].ToString();
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;//Specify your port No;
            smtp.Send(mm);
            return true;
        }
        catch
        {
            mm.Dispose();
            smtp = null;
            return false;
        }
    }
