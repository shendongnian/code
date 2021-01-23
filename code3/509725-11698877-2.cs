        SmtpClient sc = new SmtpClient("MAIL.Aramco.com");
        try
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("pssp@aramco.com", "PMOD Safety Services Portal (PSSP)");
            // In case the mail system doesn't like no to recipients. This could be removed
            //msg.To.Add("pssp@aramco.com");
            
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
