    protected void SendEmail(string toAddresses, string fromAddress, string MailSubject, string MessageBody, bool isBodyHtml)
        {
            SmtpClient sc = new SmtpClient("MailServer");
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("test@mailServer.com", "TestSystem");
    
                
                //QuizLink is appSetting inside your web config
                string newLink = System.Configuration.ConfigurationManager.AppSettings["QuizLink"].ToString();
        
        
        string html = "<h1>Quiz!</h1><img src=/fulladdress/someimage.png usemap ="#clickMap">";
        html += "<map id =\"clickMap\" name=\"clickMap\">
        <area shape =\"rect\" coords =\"0,0,82,126\" href ="+ newLink +" alt=\"Quiz\" />
        </map>"
    
                msg.Bcc.Add(toAddresses);
                msg.Subject = MailSubject;
                msg.Body = html ;
                msg.IsBodyHtml = isBodyHtml;
                sc.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
    
        }
