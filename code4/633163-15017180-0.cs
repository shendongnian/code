    public void MailSend(string strfrom, string strto, string strSubject, string strBody, string resumename, string sresumename)
    {
        try
        {
            MailMessage msg = new MailMessage(strfrom, strto);// strEmail);
           
            msg.Bcc.Add("xx@xxxx.com");
            msg.Body = strBody;
            msg.Subject = strSubject;
            msg.IsBodyHtml = true;
            if (resumename.Length > 0)
            {
                Attachment att = new Attachment(Server.MapPath(VirtualPathUtility.ToAbsolute("~/User_Resume/" + resumename)));
                msg.Attachments.Add(att);
            }
            if (sresumename.Length > 0)
            {
                Attachment att1 = new Attachment(Server.MapPath(VirtualPathUtility.ToAbsolute("~/User_Resume/" + sresumename)));
                msg.Attachments.Add(att1);
            }
            System.Net.Mail.SmtpClient cli = new System.Net.Mail.SmtpClient("111.111.111.111",25);
            cli.Credentials = new NetworkCredential("nnnnnnn", "yyyyyy");
            cli.Send(msg);
            msg.Dispose();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Enquiery submitted sucessfully');", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('"+ex.Message+"');", true);
        }
    }
