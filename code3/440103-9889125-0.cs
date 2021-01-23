     bool ret = true;
    
                try
                {
                    string _smtpServer = ConfigurationSettings.AppSettings["appEmailHost"];
    
                    Web.Mail.Mail mail = new Web.Mail.Mail(_smtpServer,         
            System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal);
                    mail._From = test@test.com;
                    mail._To = Test2@test.com;
                    mail._Subject = subject;
    
                    mail._Body = body;
                    mail.SendMail();
                    ret = true;
                }
                catch(Exception exp)
                {
                    _GravaErro(exp);
                    ret = false;
                }
    
                return ret;
